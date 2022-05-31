Public Class Agent
    Protected Shared AgentColour As Color
    Protected Shared Bounds As Size
    Protected Shared radius = 10
    Protected Shared ReadOnly borderThreashold = 0
    Protected Shared ReadOnly boundaryThreshold = borderThreashold + radius
    Protected Shared ReadOnly RndTurnStrength As Decimal = 0.5

    Private Protected position As Point
    Private Protected direction As Decimal

    Public Sub New()
        SetRandomPosDir()
    End Sub

    'getters/setters
    Public Function GetPosition() As Point
        Return Me.position
    End Function

    Public Function GetDirection() As Decimal
        Return Me.direction
    End Function

    Public Shared Sub SetColour(_Col As Color)
        AgentColour = _Col
    End Sub

    Public Shared Sub SetBounds(_Bounds As Size)
        Bounds = _Bounds
    End Sub

    Public Shared Sub SetRadius(_Radius As Decimal)
        radius = _Radius
    End Sub

    Protected Overridable Sub SetRandomPosDir()
        Dim x As Integer = Bounds.Width / 2
        Dim y As Integer = Bounds.Height / 2
        position = New Point(x, y)
        direction = Rnd() * TAU
    End Sub

    Public Overridable Sub Move(agents() As Agent, Optional speed As Decimal = 1)
        If Me.position.X <= boundaryThreshold Or Me.position.X >= Bounds.Width - boundaryThreshold Or Me.position.Y <= boundaryThreshold Or Me.position.Y >= Bounds.Height - boundaryThreshold Then
            If Me.position.X <= boundaryThreshold Then
                Me.position.X = boundaryThreshold + 1
            End If
            If Me.position.X >= Bounds.Width - boundaryThreshold Then
                Me.position.X = Bounds.Width - boundaryThreshold - 1
            End If
            If Me.position.Y <= boundaryThreshold Then
                Me.position.Y = boundaryThreshold + 1
            End If
            If Me.position.Y >= Bounds.Height - boundaryThreshold Then
                Me.position.Y = Bounds.Height - boundaryThreshold - 1
            End If
            direction += Rnd() * TAU
        End If

        direction += Rnd() * RndTurnStrength - RndTurnStrength / 2

        Dim dir As PointF = New PointF(Math.Sin(direction), Math.Cos(direction))
        dir = PointFNormalize(dir)
        Me.position.X += dir.X * speed
        Me.position.Y += dir.Y * speed
    End Sub

    Public Overridable Sub Draw(g As Graphics)
        g.FillEllipse(New SolidBrush(AgentColour), New RectangleF(position.X - radius / 2, position.Y - radius / 2, radius, radius))
    End Sub
End Class

Public Class AgentRndCol
    Inherits Agent

    Private Shadows ReadOnly AgentColour As Color

    Public Sub New()
        Randomize()
        Me.AgentColour = Color.FromArgb(Rnd() * 255, Rnd() * 255, Rnd() * 255)
        SetRandomPosDir()
    End Sub

    Public Overrides Sub Draw(g As Graphics)
        g.FillEllipse(New SolidBrush(Me.AgentColour), New RectangleF(position.X - radius / 2, position.Y - radius / 2, radius, radius))
    End Sub

End Class
