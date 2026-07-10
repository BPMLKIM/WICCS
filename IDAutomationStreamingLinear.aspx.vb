Namespace LinearStreamVB

Partial Class IDAutomationStreamingLinear
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
        'During the page load event we will set all parameters for the control			
        'Checking the Parameters using Params.Get is NOT case sensitive.  
        'However, when we use the Equals method of the string data type it IS case sensitive
        LinearBarcode1.StreamImage = True

        If Request.Params.Get("Barcode") <> "" And Request.Params.Get("Barcode") <> Nothing Then
            LinearBarcode1.DataToEncode = Trim(Request.QueryString.Get("barcode"))
        End If

        'set the Symbology
        If Request.Params.Get("CODE_TYPE") <> "" And Request.Params.Get("CODE_TYPE") <> Nothing Then
            Try
                Dim CodeTypeValue As Integer = Convert.ToInt32(Request.Params.Get("CODE_TYPE"))
                Select Case CodeTypeValue
                    Case 0
                        LinearBarcode1.SymbologyID = IDAutomation.LinearServerControl.LinearBarcode.Symbologies.Code39
                    Case 1
                        LinearBarcode1.SymbologyID = IDAutomation.LinearServerControl.LinearBarcode.Symbologies.Code39Ext
                    Case 2
                        LinearBarcode1.SymbologyID = IDAutomation.LinearServerControl.LinearBarcode.Symbologies.Interleaved25
                    Case 3
                        LinearBarcode1.SymbologyID = IDAutomation.LinearServerControl.LinearBarcode.Symbologies.Code11
                    Case 4
                        LinearBarcode1.SymbologyID = IDAutomation.LinearServerControl.LinearBarcode.Symbologies.Codabar
                    Case 5
                        LinearBarcode1.SymbologyID = IDAutomation.LinearServerControl.LinearBarcode.Symbologies.MSI
                    Case 6
                        LinearBarcode1.SymbologyID = IDAutomation.LinearServerControl.LinearBarcode.Symbologies.UPCa
                    Case 7
                        LinearBarcode1.SymbologyID = IDAutomation.LinearServerControl.LinearBarcode.Symbologies.Ind25
                    Case 8
                        LinearBarcode1.SymbologyID = IDAutomation.LinearServerControl.LinearBarcode.Symbologies.Mat25
                    Case 9
                        LinearBarcode1.SymbologyID = IDAutomation.LinearServerControl.LinearBarcode.Symbologies.Code93
                    Case 10
                        LinearBarcode1.SymbologyID = IDAutomation.LinearServerControl.LinearBarcode.Symbologies.Ean13
                    Case 11
                        LinearBarcode1.SymbologyID = IDAutomation.LinearServerControl.LinearBarcode.Symbologies.Ean8
                    Case 12
                        LinearBarcode1.SymbologyID = IDAutomation.LinearServerControl.LinearBarcode.Symbologies.UPCe
                    Case 13
                        LinearBarcode1.SymbologyID = IDAutomation.LinearServerControl.LinearBarcode.Symbologies.Code128
                    Case 14
                        LinearBarcode1.SymbologyID = IDAutomation.LinearServerControl.LinearBarcode.Symbologies.Planet

                    Case 15
                        LinearBarcode1.SymbologyID = IDAutomation.LinearServerControl.LinearBarcode.Symbologies.Postnet
                    Case 16
                        LinearBarcode1.SymbologyID = IDAutomation.LinearServerControl.LinearBarcode.Symbologies.Code93Ext
                    Case 17
                        LinearBarcode1.SymbologyID = IDAutomation.LinearServerControl.LinearBarcode.Symbologies.UCC128
                    Case 18
                        LinearBarcode1.SymbologyID = IDAutomation.LinearServerControl.LinearBarcode.Symbologies.OneCode
                End Select
            Catch
                System.Diagnostics.Debug.Write("Invalid entry for Code Type value")
            End Try
        End If

        'Set the x dimension
        If Request.Params.Get("X") <> "" And Request.Params.Get("X") <> Nothing Then
                LinearBarcode1.XDimensionCM = 0 'Request.Params.Get("X")
        End If

        'set the bar height
        If Request.Params.Get("Bar_Height") <> "" And Request.Params.Get("Bar_Height") <> Nothing Then
            LinearBarcode1.BarHeightCM = Request.Params.Get("Bar_Height")
        End If

        'set the Character Grouping
        If Request.Params.Get("CharacterGrouping") <> "" And Request.Params.Get("CharacterGrouping") <> Nothing Then
            LinearBarcode1.CharacterGrouping = Request.Params.Get("CharacterGrouping")
        End If

        If Request.Params.Get("Character_Grouping") <> "" And Request.Params.Get("Character_Grouping") <> Nothing Then
            LinearBarcode1.CharacterGrouping = Request.Params.Get("Character_Grouping")
        End If

        'set the WhiteBarIncrease
        If Request.Params.Get("WhiteBarIncrease") <> "" And Request.Params.Get("WhiteBarIncrease") <> Nothing Then
            LinearBarcode1.WhiteBarIncrease = Request.Params.Get("WhiteBarIncrease")
        End If

        If Request.Params.Get("WhiteBar_Increase") <> "" And Request.Params.Get("WhiteBar_Increase") <> Nothing Then
            LinearBarcode1.WhiteBarIncrease = Request.Params.Get("WhiteBar_Increase")
        End If

        'set the CaptionAbove
        If Request.Params.Get("CaptionAbove") <> "" And Request.Params.Get("CaptionAbove") <> Nothing Then
            LinearBarcode1.CaptionAbove = Request.Params.Get("CaptionAbove")
        End If


        'set the CaptionBelow
        If Request.Params.Get("CaptionBelow") <> "" And Request.Params.Get("CaptionBelow") <> Nothing Then
            LinearBarcode1.CaptionBelow = Request.Params.Get("CaptionBelow")
        End If
        'set the BearerBarHorizontal
        If Request.Params.Get("BearerBarHorizontal") <> "" And Request.Params.Get("BearerBarHorizontal") <> Nothing Then
            LinearBarcode1.BearerBarHorizontal = Request.Params.Get("BearerBarHorizontal")
        End If

        If Request.Params.Get("BearerBar_Horizontal") <> "" And Request.Params.Get("BearerBar_Horizontal") <> Nothing Then
            LinearBarcode1.BearerBarHorizontal = Request.Params.Get("BearerBar_Horizontal")
        End If

        'set the BearerBarVertical
        If Request.Params.Get("BearerBarVertical") <> "" And Request.Params.Get("BearerBarVertical") <> Nothing Then
            LinearBarcode1.BearerBarVertical = Request.Params.Get("BearerBarVertical")
        End If

        If Request.Params.Get("BearerBar_Vertical") <> "" And Request.Params.Get("BearerBar_Vertical") <> Nothing Then
            LinearBarcode1.BearerBarVertical = Request.Params.Get("BearerBar_Vertical")
        End If

        'determine if the check character should be calculated
        If Request.Params.Get("Check_Char") <> "" And Request.Params.Get("Check_Char") <> Nothing Then
            Dim checkCharValue As String = Request.Params.Get("Check_Char")
            If checkCharValue.Equals("Y") = True Or checkCharValue.Equals("Yes") = True Or _
                checkCharValue.Equals("True") = True Or checkCharValue.Equals("TRUE") = True Or _
                checkCharValue.Equals("y") = True Or checkCharValue.Equals("true") = True Or _
                checkCharValue.Equals("yes") = True Then

                LinearBarcode1.CheckCharacter = True
            Else
                LinearBarcode1.CheckCharacter = False
            End If
        End If

        'determine if the check character should be displayed in the text
        If Request.Params.Get("Check_Char_Text") <> "" And Request.Params.Get("Check_Char_Text") <> Nothing Then
            Dim checkCharTextValue As String = Request.Params.Get("Check_Char_Text")
            If checkCharTextValue.Equals("Y") = True Or checkCharTextValue.Equals("Yes") = True Or _
                checkCharTextValue.Equals("True") = True Or checkCharTextValue.Equals("TRUE") = True Or _
                checkCharTextValue.Equals("y") = True Or checkCharTextValue.Equals("true") = True Or _
                checkCharTextValue.Equals("yes") = True Then

                LinearBarcode1.CheckCharacterInText = True
            Else
                LinearBarcode1.CheckCharacterInText = False
            End If
        End If
        'determine if the check character should be displayed in the text (ACTT) Add check digit to text
        If Request.Params.Get("ACTT") <> "" And Request.Params.Get("ACTT") <> Nothing Then
            Dim checkCharTextValue As String = Request.Params.Get("ACTT")
            If checkCharTextValue.Equals("Y") = True Or checkCharTextValue.Equals("Yes") = True Or _
                checkCharTextValue.Equals("True") = True Or checkCharTextValue.Equals("TRUE") = True Or _
                checkCharTextValue.Equals("y") = True Or checkCharTextValue.Equals("true") = True Or _
                checkCharTextValue.Equals("yes") = True Then

                LinearBarcode1.CheckCharacterInText = True
            Else
                LinearBarcode1.CheckCharacterInText = False
            End If
        End If



        'set the rotation
        If Request.Params.Get("Rotate") <> "" And Request.Params.Get("Rotate") <> Nothing Then
            If Request.Params.Get("Rotate").Equals("90") = True Then
                LinearBarcode1.RotationAngle = IDAutomation.LinearServerControl.LinearBarcode.RotationAngles.Ninety_Degrees
            ElseIf Request.Params.Get("Rotate").Equals("180") Then
                LinearBarcode1.RotationAngle = IDAutomation.LinearServerControl.LinearBarcode.RotationAngles.One_Hundred_Eighty_Degrees
            ElseIf Request.Params.Get("Rotate").Equals("270") Then
                LinearBarcode1.RotationAngle = IDAutomation.LinearServerControl.LinearBarcode.RotationAngles.Two_Hundred_Seventy_Degrees
            Else
                LinearBarcode1.RotationAngle = IDAutomation.LinearServerControl.LinearBarcode.RotationAngles.Zero_Degrees
            End If
        End If

        'Should the human readable text be displayed
        If Request.Params.Get("Show_Text") <> "" And Request.Params.Get("Show_Text") <> Nothing Then
            Dim ShowTextValue As String = Request.Params.Get("Show_Text")
            'Equals method IS case sensitive
            If ShowTextValue.Equals("Y") = True Or ShowTextValue.Equals("y") Then
                LinearBarcode1.ShowText = True
            Else
                LinearBarcode1.ShowText = False
            End If
        End If
        If Request.Params.Get("ST") <> "" And Request.Params.Get("ST") <> Nothing Then
            Dim ShowTextValue As String = Request.Params.Get("ST")
            'Equals method IS case sensitive
            If ShowTextValue.Equals("Y") = True Or ShowTextValue.Equals("y") Then
                LinearBarcode1.ShowText = True
            Else
                LinearBarcode1.ShowText = False
            End If
        End If
        'set the left margin
        If Request.Params.Get("Left_Margin") <> "" And Request.Params.Get("Left_Margin") <> Nothing Then
                LinearBarcode1.LeftMarginCM = 0 'Request.Params.Get("Left_Margin")
        End If
        If Request.Params.Get("LM") <> "" And Request.Params.Get("LM") <> Nothing Then
                LinearBarcode1.LeftMarginCM = 0 'Request.Params.Get("LM")
        End If
        'Set the resolution of the returned image
        If Request.Params.Get("IR") <> "" And Request.Params.Get("IR") <> Nothing Then
            Try
                LinearBarcode1.ImageResolution = Convert.ToInt32(Request.Params.Get("IR"))
            Catch
                System.Diagnostics.Debug.Write("Invalid entry for Image Resolution parameter")
            End Try
        End If

        'set the top margin
        If Request.Params.Get("Top_Margin") <> "" And Request.Params.Get("Top_Margin") <> Nothing Then
            LinearBarcode1.TopMarginCM = Request.Params.Get("Top_Margin")
        End If
        If Request.Params.Get("TM") <> "" And Request.Params.Get("TM") <> Nothing Then
            LinearBarcode1.TopMarginCM = Request.Params.Get("TM")
        End If
        'Set the Code 128 character set
        If Request.Params.Get("CODE128_Set") <> "" And Request.Params.Get("CODE128_Set") <> Nothing Then
            Try
                Dim Code128SetValue As Integer = Convert.ToInt32(Request.Params.Get("CODE128_Set"))
                Select Case Code128SetValue
                    Case 0
                        LinearBarcode1.Code128Set = IDAutomation.LinearServerControl.LinearBarcode.Code128CharacterSets.Auto
                    Case 1
                        LinearBarcode1.Code128Set = IDAutomation.LinearServerControl.LinearBarcode.Code128CharacterSets.A
                    Case 2
                        LinearBarcode1.Code128Set = IDAutomation.LinearServerControl.LinearBarcode.Code128CharacterSets.B
                    Case 3
                        LinearBarcode1.Code128Set = IDAutomation.LinearServerControl.LinearBarcode.Code128CharacterSets.C
                End Select
            Catch
                System.Diagnostics.Debug.Write("Invalid entry for Code 128 Character set value")
            End Try
        End If

     



        'Set the narrow to wide ratio
        If Request.Params.Get("Narrow_Wide") <> "" And Request.Params.Get("Narrow_Wide") <> Nothing Then
            LinearBarcode1.NarrowToWideRatio = Request.Params.Get("Narrow_Wide")
        End If
        If Request.Params.Get("N") <> "" And Request.Params.Get("N") <> Nothing Then
            LinearBarcode1.NarrowToWideRatio = Request.Params.Get("N")
        End If
        'Set the margin between text and barcode
        If Request.Params.Get("Text_Margin") <> "" And Request.Params.Get("Text_Margin") <> Nothing Then
            LinearBarcode1.TextMarginCM = Request.Params.Get("Text_Margin")
        End If
        'Set the height of short bars for postnet
        If Request.Params.Get("Postnet_Tall") <> "" And Request.Params.Get("Postnet_Tall") <> Nothing Then
            LinearBarcode1.PostnetHeightTall = Request.Params.Get("Postnet_Tall")
        End If
        'Set the height of tall bars for postnet
        If Request.Params.Get("Postnet_Short") <> "" And Request.Params.Get("Postnet_Short") <> Nothing Then
            LinearBarcode1.PostnetHeightShort = Request.Params.Get("Postnet_Short")
        End If
        'set the spacing between bars for postnet
        If Request.Params.Get("Postnet_Space") <> "" And Request.Params.Get("Postnet_Space") <> Nothing Then
                LinearBarcode1.PostnetSpacing = 0 'Request.Params.Get("Postnet_Space")
        End If
        'Determine if ApplyTilde is turned on
        If Request.Params.Get("PT") <> "" And Request.Params.Get("PT") <> Nothing Then
            Dim trunValue As String = Request.Params.Get("PT")
            If trunValue.Equals("Y") = True Or trunValue.Equals("Yes") = True Or _
                trunValue.Equals("True") = True Or trunValue.Equals("TRUE") = True Or _
                trunValue.Equals("y") Or trunValue.Equals("true") = True Or _
                trunValue.Equals("yes") Then
                LinearBarcode1.ApplyTilde = True
            Else
                LinearBarcode1.ApplyTilde = False
            End If
        End If

        'fix for postnet HR bug
        If ((LinearBarcode1.SymbologyID = IDAutomation.LinearServerControl.LinearBarcode.Symbologies.Planet Or LinearBarcode1.SymbologyID = IDAutomation.LinearServerControl.LinearBarcode.Symbologies.Postnet) And LinearBarcode1.TextMarginCM <= 0.5) Then
            LinearBarcode1.TextMarginCM = 0.5
        End If
        'Set the character grouping
        If Request.Params.Get("CHARACTER_GROUPING") <> "" And Request.Params.Get("CHARACTER_GROUPING") <> Nothing Then
            LinearBarcode1.CharacterGrouping = Request.Params.Get("CHARACTER_GROUPING")
        End If
        'Set the Data to Encode
        'The following is an example for changing the font and colors of the image:
        'LinearBarcode1.ForeColor = System.Drawing.Color.Yellow
        'LinearBarcode1.BackColor = System.Drawing.Color.Black
        'LinearBarcode1.Font.Name = "Georgia"
        'LinearBarcode1.Font.Size = 16
        'LinearBarcode1.TextFontColor = System.Drawing.Color.Yellow 

        'Stream image as the selected image type
        If Request.Params.Get("FORMAT") <> "" And Request.Params.Get("FORMAT") <> Nothing Then
            Dim FormatValue As String = Request.Params.Get("FORMAT")
            'Equals method IS case sensitive
            If FormatValue.Equals("jpeg") = True Or FormatValue.Equals("JPEG") Then

                Dim imgCodecs() As System.Drawing.Imaging.ImageCodecInfo = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()

                'Create one EncoderParameters object which will contain a single element of an
                'EncodeParameter object.
                Dim imgParams As New System.Drawing.Imaging.EncoderParameters(1)
                Dim imgQuality As New System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100)

                imgParams.Param(0) = imgQuality
                Response.ContentType = "image/jpeg"
                LinearBarcode1.GetBitmapImageForBinaryStream().Save(Response.OutputStream, imgCodecs(1), imgParams)
                'LinearBarcode1.GetBitmapImageForBinaryStream().Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg)
          
            Else
                Response.ContentType = "image/gif"
                LinearBarcode1.GetBitmapImageForBinaryStream().Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif)
            End If
        Else
            Response.ContentType = "image/gif"
            LinearBarcode1.GetBitmapImageForBinaryStream().Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif)
        End If
       

    End Sub

End Class
End Namespace
