Public Class Form1
    Public Shared ScaleVal As Integer = 4000
    Public Shared Coord_Scale As Double = 0.01
    Const MidPtX As Integer = 400
    Const MidPtY As Integer = 400
    Const XNExt As Integer = -8
    Const XPExt As Integer = 9
    Const YNExt As Integer = -10
    Const YPExt As Integer = 11
    Const CntrInterval As Integer = 10
    Dim _ScV As New List(Of Surface_Holder)
    Dim _meshTri As New List(Of Mesh_Holder)

    Public Shared Function Z_Function(ByVal _XV As Double, _
                               ByVal _YV As Double) As Double
        Dim _ZVal As Double
        '------ Test function to set Z-Values
        Dim TsFunc As Integer = 3
        If TsFunc = 1 Then
            'test function to give rings above a certain level
            '_ZVal = (4 / (1 + (_XV * _XV) + (_YV * _YV))) - (3 / (1 + ((_XV * _XV) + (_YV * _YV)) * ((_XV * _XV) + (_YV * _YV))))
            _ZVal = Math.Sin(_XV * _YV)
        ElseIf TsFunc = 2 Then
            'test function to give an apparent convecting and diffusing source
            If Math.Abs(_YV) < 0.125 Then
                _ZVal = Math.Exp(-_XV) + (0.05 * (4 - _XV))
            Else
                _ZVal = Math.Exp(-_XV) * (1 - Math.Log(8 * Math.Abs(_YV))) / Math.Log(8) + (0.05 * (4 - _XV))
            End If
        ElseIf TsFunc = 3 Then
            'test function to give modulated sinusoidal dependance
            _ZVal = (Math.Cos(4 * _XV) / (1 + (_XV * _XV)) + Math.Sin(4 * _YV) / (1 + (_YV * _YV))) / 2
        End If
        Return _ZVal
    End Function

    Public Class Surface_Holder
        Dim _VXCoord As Double
        Dim _VYCoord As Double
        Dim _VXlevel As Integer
        Dim _VYlevel As Integer
        Dim _ScXCoord As Integer
        Dim _ScYCoord As Integer
        Dim _ZVal As Double

        Public ReadOnly Property VXCoord() As Double
            Get
                Return _VXCoord
            End Get
        End Property

        Public ReadOnly Property VYCoord() As Double
            Get
                Return _VYCoord
            End Get
        End Property

        Public ReadOnly Property VXlevel() As Integer
            Get
                Return _VXlevel
            End Get
        End Property

        Public ReadOnly Property VYlevel() As Integer
            Get
                Return _VYlevel
            End Get
        End Property

        Public ReadOnly Property ScXCoord() As Integer
            Get
                Return _ScXCoord
            End Get
        End Property

        Public ReadOnly Property ScYCoord() As Integer
            Get
                Return _ScYCoord
            End Get
        End Property

        Public ReadOnly Property ZVal() As Double
            Get
                Return _ZVal
            End Get
        End Property

        Public Sub Set_DCoordinates(ByVal _XV As Double, _
                                    ByVal _YV As Double, _
                                    ByVal _Xlvl As Integer, _
                                    ByVal _Ylvl As Integer)
            _VXCoord = _XV
            _VYCoord = _YV

            _VXlevel = _Xlvl
            _VYlevel = _Ylvl

            '------ Set the display x,y coordinates
            _ScXCoord = CInt(ScaleVal * _XV) + MidPtX
            _ScYCoord = MidPtY - CInt(ScaleVal * _YV) '--- inverse coordinate TOP down to Top up

            '------ Test function to set Z-Values
            _ZVal = Z_Function(_XV, _YV)

        End Sub

    End Class

    Public Class IntersectionCurve_Holder
        Dim _SPointX As Integer
        Dim _SPointY As Integer
        Dim _EPointX As Integer
        Dim _EPointY As Integer
        Dim _SPX As Double
        Dim _SPY As Double
        Dim _EPX As Double
        Dim _EPY As Double
        Dim _ZCntrLvl As Double

        Public ReadOnly Property SPointX() As Integer
            Get
                Return _SPointX
            End Get
        End Property

        Public ReadOnly Property SPointY() As Integer
            Get
                Return _SPointY
            End Get
        End Property

        Public ReadOnly Property EPointX() As Integer
            Get
                Return _EPointX
            End Get
        End Property

        Public ReadOnly Property EPointY() As Integer
            Get
                Return _EPointY
            End Get
        End Property

        Public Sub Set_CurvePoints(ByVal t_SPX As Double, _
                                   ByVal t_SPY As Double, _
                                   ByVal t_EPX As Double, _
                                   ByVal t_EPY As Double, _
                                   ByVal t_ZcntrLvl As Double)

            _SPX = t_SPX
            _SPY = t_SPY
            _EPX = t_EPX
            _EPY = t_EPY
            _ZCntrLvl = t_ZcntrLvl

            '------ Set the display x,y coordinates - one End
            _SPointX = CInt(ScaleVal * t_SPX) + MidPtX
            _SPointY = MidPtY - CInt(ScaleVal * t_SPY) '--- inverse coordinate TOP down to Top up

            '------ Set the display x,y coordinates - Second End
            _EPointX = CInt(ScaleVal * t_EPX) + MidPtX
            _EPointY = MidPtY - CInt(ScaleVal * t_EPY) '--- inverse coordinate TOP down to Top up
        End Sub
    End Class

    Public Class Mesh_Holder
        Dim _scPt1 As New Surface_Holder
        Dim _scPt2 As New Surface_Holder
        Dim _scPt3 As New Surface_Holder
        Dim ZVal1 As Double
        Dim ZVal2 As Double
        Dim ZVal3 As Double
        Dim _isecCurve As New List(Of IntersectionCurve_Holder)

        Public ReadOnly Property scPt1() As Surface_Holder
            Get
                Return _scPt1
            End Get
        End Property

        Public ReadOnly Property scPt2() As Surface_Holder
            Get
                Return _scPt2
            End Get
        End Property

        Public ReadOnly Property scPt3() As Surface_Holder
            Get
                Return _scPt3
            End Get
        End Property

        Public ReadOnly Property isecCurve() As List(Of IntersectionCurve_Holder)
            Get
                Return _isecCurve
            End Get
        End Property

        Public Sub set_Values(ByVal temp_ScPt1 As Surface_Holder, _
                              ByVal temp_ScPt2 As Surface_Holder, _
                              ByVal temp_ScPt3 As Surface_Holder)
            '----------- Just fix the three coordinates and Z values of the trianlge mesh
            _scPt1 = temp_ScPt1
            _scPt2 = temp_ScPt2
            _scPt3 = temp_ScPt3

            ZVal1 = temp_ScPt1.ZVal
            ZVal2 = temp_ScPt2.ZVal
            ZVal3 = temp_ScPt3.ZVal

            _isecCurve = New List(Of IntersectionCurve_Holder)
        End Sub

        Public Sub set_iseccurve(ByVal Cntr_Val As Double)
            Dim ZSlope1 As Double
            Dim ZSlope2 As Double
            Dim temp_isecCurve As New IntersectionCurve_Holder
            Dim _SPX As Double
            Dim _SPY As Double
            Dim _EPX As Double
            Dim _EPY As Double

            If (ZVal1 - Cntr_Val) * (ZVal2 - Cntr_Val) < 0 Then
                '--- Triangle with Zval1 or Zval 2 is below the contour range
                If (ZVal2 - Cntr_Val) * (ZVal3 - Cntr_Val) < 0 Then
                    '--- Triangle with Zval2 is above or below the contour range
                    ZSlope1 = (Cntr_Val - ZVal2) / (ZVal1 - ZVal2) '---2 to 1
                    _SPX = scPt2.VXCoord * (1 - ZSlope1) + scPt1.VXCoord * ZSlope1
                    _SPY = scPt2.VYCoord * (1 - ZSlope1) + scPt1.VYCoord * ZSlope1

                    ZSlope2 = (Cntr_Val - ZVal2) / (ZVal3 - ZVal2) '---2 to 3
                    _EPX = scPt2.VXCoord * (1 - ZSlope2) + scPt3.VXCoord * ZSlope2
                    _EPY = scPt2.VYCoord * (1 - ZSlope2) + scPt3.VYCoord * ZSlope2

                    temp_isecCurve.Set_CurvePoints(_SPX, _SPY, _EPX, _EPY, Cntr_Val)
                ElseIf (ZVal1 - Cntr_Val) * (ZVal3 - Cntr_Val) < 0 Then
                    '--- Triangle with Zval1 is above or below the contour range
                    ZSlope1 = (Cntr_Val - ZVal1) / (ZVal2 - ZVal1) '---1 to 2
                    _SPX = scPt1.VXCoord * (1 - ZSlope1) + scPt2.VXCoord * ZSlope1
                    _SPY = scPt1.VYCoord * (1 - ZSlope1) + scPt2.VYCoord * ZSlope1

                    ZSlope2 = (Cntr_Val - ZVal1) / (ZVal3 - ZVal1) '---1 to 3
                    _EPX = scPt1.VXCoord * (1 - ZSlope2) + scPt3.VXCoord * ZSlope2
                    _EPY = scPt1.VYCoord * (1 - ZSlope2) + scPt3.VYCoord * ZSlope2

                    temp_isecCurve.Set_CurvePoints(_SPX, _SPY, _EPX, _EPY, Cntr_Val)
                End If
            ElseIf (ZVal2 - Cntr_Val) * (ZVal3 - Cntr_Val) < 0 Then
                If (ZVal1 - Cntr_Val) * (ZVal3 - Cntr_Val) < 0 Then
                    '--- Triangle with Zval 3 is above or below  the contour range
                    ZSlope1 = (Cntr_Val - ZVal3) / (ZVal1 - ZVal3) '---3 to 1
                    _SPX = scPt3.VXCoord * (1 - ZSlope1) + scPt1.VXCoord * ZSlope1
                    _SPY = scPt3.VYCoord * (1 - ZSlope1) + scPt1.VYCoord * ZSlope1

                    ZSlope2 = (Cntr_Val - ZVal3) / (ZVal2 - ZVal3) '---3 to 2
                    _EPX = scPt3.VXCoord * (1 - ZSlope2) + scPt2.VXCoord * ZSlope2
                    _EPY = scPt3.VYCoord * (1 - ZSlope2) + scPt2.VYCoord * ZSlope2

                    temp_isecCurve.Set_CurvePoints(_SPX, _SPY, _EPX, _EPY, Cntr_Val)
                End If
            End If
            _isecCurve.Add(temp_isecCurve)
        End Sub
    End Class

#Region " Main Pic Events"
    Private Sub Main_Pic_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Main_Pic.Paint
        e.Graphics.DrawLine(Pens.Blue, MidPtX, 0, MidPtX, 900)
        e.Graphics.DrawLine(Pens.Blue, 0, MidPtY, 800, MidPtY)
        'Dim i, j As Integer

        '----------- Coordinates
        'For Each Sc In _ScV
        '    e.Graphics.DrawEllipse(Pens.Blue, Sc.ScXCoord - CInt(ScaleVal * 0.5), Sc.ScYCoord - CInt(ScaleVal * 0.5), ScaleVal, ScaleVal)
        'Next

        '----------- Mesh_Triangle
        For Each M_T In _meshTri
            e.Graphics.DrawLine(Pens.Blue, M_T.scPt1.ScXCoord, M_T.scPt1.ScYCoord, _
                                           M_T.scPt2.ScXCoord, M_T.scPt2.ScYCoord)
            e.Graphics.DrawLine(Pens.Blue, M_T.scPt2.ScXCoord, M_T.scPt2.ScYCoord, _
                                          M_T.scPt3.ScXCoord, M_T.scPt3.ScYCoord)
            e.Graphics.DrawLine(Pens.Blue, M_T.scPt3.ScXCoord, M_T.scPt3.ScYCoord, _
                                          M_T.scPt1.ScXCoord, M_T.scPt1.ScYCoord)
            For Each int_Sec In M_T.isecCurve
                e.Graphics.DrawLine(Pens.Black, int_Sec.SPointX, int_Sec.SPointY, _
                                               int_Sec.EPointX, int_Sec.EPointY)
            Next
        Next

        '---- Pain Zoom Status
        e.Graphics.DrawString(Coord_Scale, New Font("Verdana", 12), Brushes.Blue, 700, 800)
    End Sub
#End Region


    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      
    End Sub

    Private Sub Button_SetVals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_SetVals.Click
        Execute_ZFunction()
    End Sub

    Public Sub Execute_ZFunction()
        Dim i, j As Integer

        '----------- Set Z_Function with the text values



        '-------- Fix X, Y, Z_Values for Surface
        _ScV = New List(Of Surface_Holder)
        For i = XNExt To XPExt Step +1
            For j = YNExt To YPExt Step +1
                Dim temp_ScV As New Surface_Holder
                Dim temp_X As Double
                Dim temp_Y As Double
                temp_X = Coord_Scale * ((i - 1) + ((Math.Abs(j) + 2) Mod 2) * 0.5)
                temp_Y = Coord_Scale * ((j - 1) * Math.Sqrt(3) * 0.5)
                temp_ScV.Set_DCoordinates(temp_X, temp_Y, i, j)
                _ScV.Add(temp_ScV)
            Next
        Next

        '-------- Fix Triangle Mesh
        _meshTri = New List(Of Mesh_Holder)
        For i = XNExt To (XPExt - 1) Step +1
            Dim k0 As Integer = i
            Dim Sc_tep1 As New List(Of Surface_Holder)
            Sc_tep1 = _ScV.Where(Function(c) c.VXlevel = k0 + 0).ToList
            Dim Sc_tep2 As New List(Of Surface_Holder)
            Sc_tep2 = _ScV.Where(Function(c) c.VXlevel = k0 + 1).ToList
            For j = YNExt To (YPExt - 1) Step +1
                Dim k1 As Integer = j
                Dim temp_MeshTri As Mesh_Holder

                '--------- Triangle
                Dim op1 As Integer = If((Math.Abs(j)) Mod 2 = 0, j, j + 1)
                Dim ScPt1, ScPt2, ScPt3 As Surface_Holder
                ScPt1 = Sc_tep1.Find(Function(c) c.VYlevel = k1)
                ScPt2 = Sc_tep1.Find(Function(c) c.VYlevel = (k1 + 1))
                ScPt3 = Sc_tep2.Find(Function(c) c.VYlevel = (op1))
                temp_MeshTri = New Mesh_Holder
                temp_MeshTri.set_Values(ScPt1, ScPt2, ScPt3)
                _meshTri.Add(temp_MeshTri)

                '---------- Inverse Triangle
                Dim op2 As Integer = If((Math.Abs(j)) Mod 2 = 0, j + 1, j)
                ScPt1 = Sc_tep2.Find(Function(c) c.VYlevel = k1)
                ScPt2 = Sc_tep2.Find(Function(c) c.VYlevel = (k1 + 1))
                ScPt3 = Sc_tep1.Find(Function(c) c.VYlevel = (op2))
                temp_MeshTri = New Mesh_Holder
                temp_MeshTri.set_Values(ScPt1, ScPt2, ScPt3)
                _meshTri.Add(temp_MeshTri)
            Next
        Next

        '-------- Find the contour intersection
        Dim ZNExt, ZPExt As Double
        ZNExt = 100000
        ZPExt = -100000
        For Each _Sc In _ScV
            If ZNExt > _Sc.ZVal Then
                ZNExt = _Sc.ZVal
            End If
            If ZPExt < _Sc.ZVal Then
                ZPExt = _Sc.ZVal
            End If
        Next
        Dim cntrLvl As Double
        For i = 1 To (CntrInterval - 1) Step +1
            cntrLvl = ZNExt + ((ZPExt - ZNExt) / CntrInterval) * i
            '-------- Set contour level
            For Each _MeshT In _meshTri
                _MeshT.set_iseccurve(cntrLvl)
            Next
        Next

        MT_Pic.Refresh()
    End Sub

    Private Sub ComboBox_ZVal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_ZVal.SelectedIndexChanged
        If ComboBox_ZVal.SelectedIndex = 0 Then
            ScaleVal = 40
            Coord_Scale = 1
        ElseIf ComboBox_ZVal.SelectedIndex = 1 Then
            ScaleVal = 400
            Coord_Scale = 0.1
        ElseIf ComboBox_ZVal.SelectedIndex = 2 Then
            ScaleVal = 4000
            Coord_Scale = 0.01
        ElseIf ComboBox_ZVal.SelectedIndex = 3 Then
            ScaleVal = 40000
            Coord_Scale = 0.001
        End If
        Execute_ZFunction()
    End Sub
End Class
