Namespace LinearStreamVB

Partial Class WebForm1
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Me.IsPostBack Then
            Image1.Visible = True
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'This routine will construct a URL request for an IMG tag to assign to the ImageURL property of the image control
        'on the web form.
        Dim SymID As String = ""
        Dim checkChar As String = ""
        Dim checkCharText As String = ""
        Dim showText As String = ""

        'Set the value determining if a check character should be calculated.
        If chkCheckChar.Checked = True Then
            checkChar = "y"
        Else
            checkChar = "n"
        End If

        'Set the value determining if the check character should be displayed in the human readable text
        If chkCheckCharText.Checked = True Then
            checkCharText = "y"
        Else
            checkCharText = "n"
        End If

        'Set the value determining if the human readable text should be displayed.
        If chkShowText.Checked = True Then
            showText = "y"
        Else
            showText = "n"
        End If

        'Set the symbology ID.  This will be converted by IDAutomationStreamImage page to a specific 
        'symbology.
        Select Case lstSymbology.SelectedItem.Text
            Case "Code39"
                SymID = "0"
            Case "Code39EXT"
                SymID = "1"
            Case "Interleaved 2 of 5"
                SymID = "2"
            Case "Code11"
                SymID = "3"
            Case "Codabar"
                SymID = "4"
            Case "MSI"
                SymID = "5"
            Case "UPCA"
                SymID = "6"
            Case "IND25"
                SymID = "7"
            Case "MAT25"
                SymID = "8"
            Case "Code93"
                SymID = "9"
            Case "EAN13"
                SymID = "10"
            Case "EAN8"
                SymID = "11"
            Case "UPCE"
                SymID = "12"
            Case "Code128"
                SymID = "13"
            Case "Planet"
                SymID = "14"
            Case "Postnet"
                SymID = "15"
            Case "Code93EXT"
                SymID = "16"
            Case "UCC128"
                SymID = "17"
            Case "OneCode"
                SymID = "18"

        End Select

        'Set the rotation angle
        Dim RotAngle As String = ""
        Select Case lstRotation.SelectedItem.Text
            Case "0 Degrees"
                RotAngle = "0"
            Case "90 Degrees"
                RotAngle = "90"
            Case "180 Degrees"
                RotAngle = "180"
            Case "270 Degrees"
                RotAngle = "270"

        End Select

        'create the URL request to set the image control to.
        Image1.ImageUrl = "IDAutomationStreamingLinear.aspx?barcode=" & txtBarcode.Text & "&X=" & txtX.Text & _
         "&CODE_TYPE=" & SymID & "&ROTATE=" & RotAngle & "&Bar_Height=" + txtBarHeight.Text & _
         "&Left_Margin=" & txtLM.Text & "&Top_Margin=" & txtTopMargin.Text + "&Check_Char=" & checkChar & _
         "&Check_Char_Text=" & checkCharText & "&Show_Text=" & showText + "&IR=" & txtResolution.Text & _
         "&BearerBarVertical=" & txtBearerBars.Text & "&BearerBarHorizontal=" & txtBearerBars.Text & "&WhiteBarIncrease=" & txtWhiteBarIncrease.Text & _
         "&CharacterGrouping=" & txtCharacterGroup.Text & "&CaptionAbove=" & txtCaptionAbove.Text & "&CaptionBelow=" & txtCaptionBelow.Text

    End Sub

    Private Sub lstSymbology_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSymbology.SelectedIndexChanged

    End Sub
End Class
End Namespace
