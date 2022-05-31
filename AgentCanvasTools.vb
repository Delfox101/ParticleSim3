Public Class AgentCanvasTools
    Const evaporateSpeed As Decimal = 2

    Public Function Blur(canvas As Bitmap, diffusionSpeed As Decimal)
        'Dim bData As Imaging.BitmapData = canvas.LockBits(New Rectangle(0, 0, canvas.Width, canvas.Height), Imaging.ImageLockMode.ReadWrite, Imaging.PixelFormat.Format32bppRgb)
        For x = 0 To canvas.Width - 1
            For y = 0 To canvas.Height - 1
                Dim sum As New Decimal3 With {.x = 0, .y = 0, .z = 0}
                Dim originalValueC = canvas.GetPixel(x, y)
                Dim originalValue = New Decimal3 With {.x = originalValueC.R, .y = originalValueC.G, .z = originalValueC.B}

                For ex = -1 To 1
                    For ey = -1 To 1
                        Dim sampleX As Decimal = x + ex
                        Dim sampleY As Decimal = y + ey

                        If sampleX >= 0 And sampleX < canvas.Width And sampleY >= 0 And sampleY < canvas.Height Then
                            sum = Decimal3.AddColourVals(sum, canvas.GetPixel(sampleX, sampleY))
                        End If
                    Next
                Next

                'average of surrounding pixels
                Dim blurResult As Decimal3 = Decimal3.DivVals(sum, 9)

                Dim diffusedValue As Decimal3 = Decimal3.Lerp(originalValue, blurResult, diffusionSpeed)
                Dim diffusedAndEvaporatedValue As Decimal3 = Decimal3.Max(Decimal3.zero, Decimal3.SubVals(diffusedValue, evaporateSpeed - diffusionSpeed))
                canvas.SetPixel(x, y, Color.FromArgb(diffusedAndEvaporatedValue.x, diffusedAndEvaporatedValue.y, diffusedAndEvaporatedValue.z))
            Next
        Next
        'canvas.UnlockBits(bData)
        Return canvas
    End Function

End Class

Module FunctionGraveyard
    'Public Const CanvasBackground As Color = Color.AliceBlue
    'SETTINGS

    Public Const framerate As Integer = 60
    Public Const TrailDiffusionSpeed As Decimal = 1

    Public Const TAU As Decimal = 2 * Math.PI

    Public Structure Decimal3
        Dim x As Decimal
        Dim y As Decimal
        Dim z As Decimal

        Public Shared zero = New Decimal3 With {.x = 0, .y = 0, .z = 0}
        Public Shared one = New Decimal3 With {.x = 1, .y = 1, .z = 1}

        Public Shared Function AddColourVals(vals As Decimal3, col As Color)
            Return New Decimal3 With {.x = vals.x + col.R, .y = vals.y + col.G, .z = vals.z + col.G}
        End Function

        Public Shared Function DivVals(vals As Decimal3, div As Decimal)
            Return New Decimal3 With {.x = vals.x / div, .y = vals.y / div, .z = vals.z / div}
        End Function

        Public Shared Function SubVals(d As Decimal3, v As Decimal)
            Return New Decimal3 With {.x = d.x - v, .y = d.y - v, .z = d.z - v}
        End Function

        Public Shared Function Lerp(d1 As Decimal3, d2 As Decimal3, p As Decimal) As Decimal3
            Dim DR = d2.x - d1.x
            Dim DG = d2.y - d1.y
            Dim DB = d2.z - d1.z
            Return New Decimal3 With {
            .x = d1.x + p * DR,
            .y = d1.y + p * DG,
            .z = d1.z + p * DB}
        End Function

        Public Shared Function Max(d1 As Decimal3, d2 As Decimal3)
            Dim d As New Decimal3
            d.x = Math.Max(d1.x, d2.x)
            d.y = Math.Max(d1.y, d2.y)
            d.z = Math.Max(d1.z, d2.z)
            Return d
        End Function

    End Structure

    Function PointDist(p1 As Point, p2 As Point)
        Dim d As Decimal = (((p2.X - p1.X) ^ 2) + ((p2.Y - p1.Y) ^ 2)) ^ 0.5
        Return d
    End Function

    Function PointFNormalize(p As PointF)
        Dim mag As Decimal = (p.X ^ 2 + p.Y ^ 2) ^ 0.5
        Return New PointF(p.X / mag, p.Y / mag)
    End Function

    Function PointFDiv(p As PointF, d As Decimal)
        Return New PointF(p.X / d, p.Y / d)
    End Function

    Function LerpF(x As Decimal, y As Decimal, t As Decimal)
        Return x + t * (y - x)
    End Function

End Module