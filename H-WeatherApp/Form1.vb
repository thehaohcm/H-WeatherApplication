Public Class Form1
    Private Function ThoiTiet(ByVal str As String) As String
        Select Case str
            Case "Fog."
                Return "Sương mù"
            Case "Partly Cloudy."
                Return "Trời ít mây"
            Case "Wind."
                Return "Nhiều gió"
            Case "Mostly Cloudy."
                Return "Trời nhiều mây"
            Case "Cloudy."
                Return "Nhiều Mây"
            Case "Clear."
                Return "Trời mát mẻ"
            Case "Light Rain."
                Return "Mưa rào nhẹ"
            Case "Drizzle."
                Return "Mưa bụi"
            Case "Light Drizzle."
                Return "Mưa phùn nhẹ"
            Case "Thunderstorms."
                Return "Mưa dông"
            Case "Scattered Thunderstorms."
                Return "Mưa dông rải rác"
            Case "AM Thunderstorms."
                Return "Sấm sét buổi sáng"
            Case "AM Thunderstorms/Windy."
                Return "Sấm kèm theo gió buổi sáng"
            Case "Heavy Rain."
                Return "Mưa lớn"
            Case "Sunny."
                Return "Trời Nắng"
            Case "Fair."
                Return "Trời đẹp"
            Case "Thunder."
                Return "Sấm sét"
            Case "Light Rain with Thunder."
                Return "Mưa to kèm sấm sét"
            Case "Thunder in the Vicinity." 'Or "Scattered Thunderstorms."
                Return "Một vài nơi có sấm sét"
            Case "Heavy Thunderstorm."
                Return "Mưa giông"
            Case "Heavy Rain/Windy."
                Return "Mưa lớn kèm gió to"
            Case "Mist."
                Return "Sương mù rải rác"
            Case "Mostly Cloudy/Windy."
                Return "Nhiều Mây, Gió"
            Case "Rain."
                Return "Mưa"
            Case "Mostly Sunny."
                Return "Nắng to"
            Case "AM Showers."
                Return "Có mưa rào buổi sáng"
            Case "AM Clouds/PM Sun."
                Return "Sáng mây/Chiều nắng"
            Case "Few Showers."
                Return "Mưa rào rải rác"
            Case "PM Thunderstorms."
                Return "Sấm sét vào chiều"
            Case "Showers."
                Return "Mưa rào"
            Case "Hot."
                Return "Trời nóng"
            Case "Isolated Thunderstorm."
                Return "Có sấm chớp"
            Case Else
                Return str
        End Select
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If My.Computer.Network.IsAvailable = False Then
                MessageBox.Show("Máy bạn chưa được kết nối với Internet, Chương trình không thể cập nhật và thông báo chính xác cho bạn biết về thông tin thời tiết", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                ComboBox1.Text = "Hồ Chí Minh City"
                LastBuildData.Text = "Erorr!"
                Button1_Click(sender, e)
                Timer1.Enabled = True
                Timer2.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show("Đã có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Dim chay As Integer = 0

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        chay += 1
        
        If chay = 3 Then
            chay = 0
            ProgressBar1.Value -= 1
            If ProgressBar1.Value = 0 Then
                Button1_Click(sender, e)

            End If
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Select Case ComboBox1.Text
            Case "An Nhơn"
                TextBox1.Text = "VMXX0001"
            Case "Bắc Giang"
                TextBox1.Text = "VMXX0002"
            Case "Bạch Long Vĩ"
                TextBox1.Text = "VMXX0024"
            Case "Biên Hoà"
                TextBox1.Text = "VMXX0003"
            Case "Cà Mau"
                TextBox1.Text = "VMXX0031"
            Case "Cần Thơ"
                TextBox1.Text = "VMXX0004"
            Case "Cao Bằng"
                TextBox1.Text = "VMXX0020"
            Case "Côn Sơn"
                TextBox1.Text = "VMXX0033"
            Case "Đà Nẵng"
                TextBox1.Text = "VMXX0028"
            Case "Đồng Hới"
                TextBox1.Text = "VMXX0027"
            Case "Hải Phòng"
                TextBox1.Text = "VMXX0005"
            Case "Hà Nội"
                TextBox1.Text = "VMXX0006"
            Case "Hồ Chí Minh City"
                TextBox1.Text = "VMXX0007"
            Case "Hoà Bình"
                TextBox1.Text = "VMXX0008"
            Case "Huế"
                TextBox1.Text = "VMXX0009"
            Case "Lạng Sơn"
                TextBox1.Text = "VMXX0023"
            Case "Lào Cai (Sa Pa)"
                TextBox1.Text = "VMXX0019"
            Case "Mỹ Tho"
                TextBox1.Text = "VMXX0010"
            Case "Nam Định"
                TextBox1.Text = "VMXX0011"
            Case "Nha Trang"
                TextBox1.Text = "VMXX0029"
            Case "Phan Thiết"
                TextBox1.Text = "VMXX0012"
            Case "Phú Liên"
                TextBox1.Text = "VMXX0022"
            Case "Phú Quốc"
                TextBox1.Text = "VMXX0032"
            Case "Quy Nhơn"
                TextBox1.Text = "VMXX0013"
            Case "Sông Cầu"
                TextBox1.Text = "VMXX0014"
            Case "Sông Tử Tây"
                TextBox1.Text = "VMXX0030"
            Case "Thái Nguyên"
                TextBox1.Text = "VMXX0015"
            Case "Thanh Hoá"
                TextBox1.Text = "VMXX0025"
            Case "Trường Sa"
                TextBox1.Text = "VMXX0034"
            Case "Tuy Hoà"
                TextBox1.Text = "VMXX0016"
            Case "Việt Trì"
                TextBox1.Text = "VMXX0017"
            Case "Vinh"
                TextBox1.Text = "VMXX0026"
            Case "Vũng Tàu"
                TextBox1.Text = "VMXX0018"
        End Select
        Button1_Click(sender, e)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try

            Dim weather As New H_Weather(TextBox1.Text, "c")
            Dim Next_Weather As New ClassWeather(TextBox1.Text, "c")
            Dim doC As Integer
            doC = Convert.ToInt32(weather.Temp)
            GroupBox1.Text = "Hôm nay: " + weather.Day
            GroupBox2.Text = " " + Next_Weather.Thu_Tomorrow + ": "
            GroupBox3.Text = Next_Weather.Thu_NextDay + ": "
            GroupBox4.Text = Next_Weather.Thu_NextToDay + ": "

            Me.Text = "H-WeatherApp | " + weather.City + " - " + weather.Country



            Label1.Text = weather.High + "°C"
            Label2.Text = weather.Low + "°C"
            Label3.Text = weather.SunRise + " AM"
            Label8.Text = weather.Sunset + " PM"
            Label15.Text = weather.Speed + " km/h"
            Label16.Text = weather.Humidity + "%"
            Label14.Text = weather.Pressure + " mb"
            Label9.Text = ThoiTiet(weather.Status)
            Label22.Text = Next_Weather.High_Tomorrow & "°C"
            Label23.Text = Next_Weather.Low_Tomorrow & "°C"
            Label24.Text = Next_Weather.High_NextDay & "°C"
            Label25.Text = Next_Weather.Low_NextDay & "°C"
            Label26.Text = Next_Weather.High_NextToDay & "°C"
            Label27.Text = Next_Weather.Low_NextToDay & "°C"
            Label28.Text = ThoiTiet(Next_Weather.Stt_Tomorrow)
            Label30.Text = ThoiTiet(Next_Weather.Stt_NextDay)
            Label32.Text = ThoiTiet(Next_Weather.Stt_NextToDay)
            Label37.Text = weather.Visibility + " km"
            Label39.Text = weather.Direction + "°"
            Label41.Text = weather.Chill + "°C"
            Label43.Text = weather.Rising
            weather.Rising()


            Temp.Text = weather.Temp + "°C"

            Timer1.Enabled = True
            ProgressBar1.Value = 100
            chay = 0

            If doC < 10 Then
                Temp.ForeColor = Color.Aqua
            ElseIf doC >= 10 And doC < 20 Then
                Temp.ForeColor = Color.LightSkyBlue
            ElseIf (doC >= 20) And (doC < 30) Then
                Temp.ForeColor = Color.DeepSkyBlue
            ElseIf doC >= 30 And doC < 40 Then
                Temp.ForeColor = Color.Crimson
            ElseIf doC > 40 Then
                Temp.ForeColor = Color.Red
            Else
                Temp.ForeColor = Color.LightSkyBlue
            End If
            PictureBox1.ImageLocation = weather.GetImage
            LastBuildData.Text = weather.LastBuilData
        Catch ex As Exception
            MessageBox.Show("Đã có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Timer1.Enabled = False
            ProgressBar1.Value = 100
        End Try

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        TextBox1.ReadOnly = True
        ComboBox1.Enabled = True

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        ComboBox1.Enabled = False
        TextBox1.ReadOnly = False
    End Sub

    Private Sub GiớiThiệuVềHWeatherAppToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GiớiThiệuVềHWeatherAppToolStripMenuItem.Click
        AboutBox1.Show()

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim gio, phut, giay As String
        If My.Computer.Clock.LocalTime.Hour < 10 Then
            gio = "0" + My.Computer.Clock.LocalTime.Hour.ToString
        Else
            gio = My.Computer.Clock.LocalTime.Hour.ToString
        End If
        If My.Computer.Clock.LocalTime.Minute < 10 Then
            phut = "0" + My.Computer.Clock.LocalTime.Minute.ToString
        Else
            phut = My.Computer.Clock.LocalTime.Minute.ToString

        End If
        If My.Computer.Clock.LocalTime.Second < 10 Then
            giay = "0" + My.Computer.Clock.LocalTime.Second.ToString
        Else
            giay = My.Computer.Clock.LocalTime.Second.ToString
        End If
        ToolLabel2.Text = gio + " : " + phut + " : " + giay
    End Sub
End Class
