Imports System.Web.RegularExpressions
Imports System.Text.RegularExpressions

Public Class H_Weather
    'Public Value
    Dim FullTextXML As String
    Dim PartTextXML As String
    'Constructor
    Sub New(ByVal p As String, ByVal u As String)
        Dim doc As New System.Xml.XmlDocument()
        Dim str As String = "http://xml.weather.yahoo.com/forecastrss?p=" & p & "&u=" & u
        Try
            doc.Load(str)
            str = doc.OuterXml
            FullTextXML = doc.OuterXml 'Lay source cua trang xml weather yahoo
            PartTextXML = GetStr(str)
        Catch ex As Exception
            str = "Null"
            FullTextXML = "Null"
            Throw New Exception("Null XML")
        End Try
    End Sub

    'Private Function
    Private Function GetStr(ByVal str As String) As String
        Try
            Dim index1 As Integer
            Dim index2 As Integer
            index1 = (str.IndexOf("<![CDATA[")) + Len("<![CDATA[")
            index2 = (str.IndexOf("]]>"))
            Dim str1 As String = str.Substring(index1, index2 - index1)
            Return str1
        Catch ex As Exception
            Return "Error"
        End Try
    End Function

    Private Function GetWeather(ByVal str As String) As String
        Dim index1 As Integer
        Dim index2 As Integer
        Dim newstr As String
        index1 = str.IndexOf("<yweather:forecast") + Len("<yweather:forecast")
        newstr = str.Substring(index1)
        index2 = newstr.IndexOf("/>")
        Dim str1 As String = newstr.Substring(0, index2)
        Return str1
    End Function

    Private Function GetAtmosphere(ByVal str As String) As String
        Dim index1 As Integer = str.IndexOf("<yweather:atmosphere") + Len("<yweather:atmosphere")
        Dim NewStr As String = str.Substring(index1)
        Dim index2 As Integer = NewStr.IndexOf("/>")
        Dim ss As String = NewStr.Substring(0, index2)
        Return ss
    End Function

    Private Function GetCondition(ByVal str As String) As String
        Dim index1 As Integer = str.IndexOf("<yweather:condition") + Len("<yweather:condition")
        Dim NewStr As String = str.Substring(index1)
        Dim index2 As Integer = NewStr.IndexOf("/>")
        Dim ss As String = NewStr.Substring(0, index2)
        Return ss
    End Function

    Private Function GetAstronomy(ByVal str As String) As String
        Dim index1 As Integer = str.IndexOf("<yweather:astronomy") + Len("<yweather:astronomy")
        Dim NewStr As String = str.Substring(index1)
        Dim index2 As Integer = NewStr.IndexOf("/>")
        Dim ss As String = NewStr.Substring(0, index2)
        Return ss
    End Function

    Private Function GetWind(ByVal str As String) As String
        Dim index1 As Integer = str.IndexOf("<yweather:wind") + Len("<yweather:wind")
        Dim NewStr As String = str.Substring(index1)
        Dim index2 As Integer = NewStr.IndexOf("/>")
        Dim ss As String = NewStr.Substring(0, index2)
        Return ss
    End Function

    Private Function FormatString(ByVal [string] As String) As String
        Dim c As Char = [string].Chars(0)
        c = UCase(c)
        Dim str As String
        str = c & [string].Substring(1)
        Return str
    End Function

    Private Function LastBuilData(ByVal str As String) As String
        Dim index1 As Integer = str.IndexOf("<lastBuildDate>") + Len("<lastBuildDate>")
        Dim NewStr As String = str.Substring(index1)
        Dim index2 As Integer = NewStr.IndexOf("</lastBuildDate>")
        Dim ss As String = NewStr.Substring(0, index2)
        Return ss
    End Function

    Private Function location(ByVal str As String) As String
        Dim index1 As Integer = Str.IndexOf("<yweather:location") + Len("<yweather:location")
        Dim NewStr As String = Str.Substring(index1)
        Dim index2 As Integer = NewStr.IndexOf("/>")
        Dim ss As String = NewStr.Substring(0, index2)
        Return ss
    End Function

    'Friend Function

    Friend Function FCstr() As String
        Dim T As String = GetStr(FullTextXML)
        Dim index1 As Integer = T.IndexOf("Forecast:</b><BR />") + Len("Forecast:</b><BR />")
        Dim st1 As String = T.Substring(index1)
        Dim index2 As String = st1.IndexOf("<br />") + Len("<br />")
        Dim st2 As String = st1.Substring(index2)
        index1 = st2.IndexOf("<a href=")
        st1 = st2.Substring(0, index1)
        Return st1
    End Function




    'Public Function
    Function GetWeather() As String 'Hàm public dùng để sử dụng trong chương trình
        Return GetWeather(FullTextXML) 'Gọi hàm GetWeather(Byval Str As string) private
    End Function

    Function Low() As String
        Dim T As String
        T = GetWeather(FullTextXML).ToLower
        Dim index1 As Integer
        Dim index2 As Integer
        Dim NewStr As String
        index1 = T.IndexOf("low")
        NewStr = T.Substring(index1)
        index2 = NewStr.IndexOf(" ")
        Dim ss As String = NewStr.Substring(0, index2)
        Dim arr() As String = ss.Split("=")
        Return arr(1).Replace("""", "")
    End Function

    Function High() As String
        Dim T As String = GetWeather(FullTextXML).ToLower
        Dim index1 As Integer = T.IndexOf("high")
        Dim NewStr As String = T.Substring(index1)
        Dim index2 As Integer = NewStr.IndexOf(" ")
        Dim ss As String = NewStr.Substring(0, index2)
        Dim arr() As String = ss.Split("=")
        Return arr(1).Replace("""", "")
    End Function

    Function Day() As String
        Dim S As String = GetWeather(FullTextXML).ToLower
        Dim index1 As Integer = S.IndexOf("day")
        Dim NewStr As String = S.Substring(index1)
        Dim index2 As Integer = NewStr.IndexOf(" ")
        Dim ss As String = NewStr.Substring(0, index2)
        Dim arr() As String = ss.Split("=")
        Dim d As String = FormatString(arr(1).Replace("""", ""))
        Select Case d
            Case "Sun"
                Return "Chủ Nhật"
            Case "Mon"
                Return "Thứ Hai"
            Case "Tue"
                Return "Thứ Ba"
            Case "Wed"
                Return "Thứ Tư"
            Case "Thu"
                Return "Thứ Năm"
            Case "Fri"
                Return "Thứ Sáu"
            Case "Sat"
                Return "Thứ Bảy"
            Case Else
                Return "NULL"
        End Select
    End Function


    Function SunRise() As String
        Dim S As String = GetAstronomy(FullTextXML).ToLower
        Dim index1 As Integer = S.IndexOf("sunrise")
        Dim NewStr As String = S.Substring(index1)
        Dim index2 As Integer = NewStr.IndexOf(" ")
        Dim ss As String = NewStr.Substring(0, index2)
        Dim arr() As String = ss.Split("=")
        Return arr(1).Replace("""", "")
    End Function

    Function Sunset() As String
        Dim S As String = GetAstronomy(FullTextXML).ToLower
        Dim index1 As Integer = S.IndexOf("sunset")
        Dim NewStr As String = S.Substring(index1)
        Dim index2 As Integer = NewStr.IndexOf(" ")
        Dim ss As String = NewStr.Substring(0, index2)
        Dim arr() As String = ss.Split("=")
        Return arr(1).Replace("""", "")
    End Function

    Function Chill() As String
        Dim S As String = GetWind(FullTextXML).ToLower
        Dim index1 As Integer = S.IndexOf("chill")
        Dim NewStr As String = S.Substring(index1)
        Dim index2 As Integer = NewStr.IndexOf(" ")
        Dim ss As String = NewStr.Substring(0, index2)
        Dim arr() As String = ss.Split("=")
        Return arr(1).Replace("""", "")
    End Function

    Function Direction() As String
        Dim S As String = GetWind(FullTextXML).ToLower
        Dim index1 As Integer = S.IndexOf("direction")
        Dim NewStr As String = S.Substring(index1)
        Dim index2 As Integer = NewStr.IndexOf(" ")
        Dim ss As String = NewStr.Substring(0, index2)
        Dim arr() As String = ss.Split("=")
        Return arr(1).Replace("""", "")
    End Function

    Function Speed() As String
        Dim S As String = GetWind(FullTextXML).ToLower
        Dim index1 As Integer = S.IndexOf("speed")
        Dim NewStr As String = S.Substring(index1)
        Dim index2 As Integer = NewStr.IndexOf(" ")
        Dim ss As String = NewStr.Substring(0, index2)
        Dim arr() As String = ss.Split("=")
        Return arr(1).Replace("""", "")
    End Function

    Function Humidity() As String
        Dim S As String = GetAtmosphere(FullTextXML).ToLower
        Dim index1 As Integer = S.IndexOf("humidity")
        Dim NewStr As String = S.Substring(index1)
        Dim index2 As Integer = NewStr.IndexOf(" ")
        Dim ss As String = NewStr.Substring(0, index2)
        Dim arr() As String = ss.Split("=")
        Return arr(1).Replace("""", "")
    End Function

    Function Visibility() As String
        Dim S As String = GetAtmosphere(FullTextXML).ToLower
        Dim index1 As Integer = S.IndexOf("visibility")
        Dim NewStr As String = S.Substring(index1)
        Dim index2 As Integer = NewStr.IndexOf(" ")
        Dim ss As String = NewStr.Substring(0, index2)
        Dim arr() As String = ss.Split("=")
        Return arr(1).Replace("""", "")
    End Function

    Function Pressure() As String
        Dim S As String = GetAtmosphere(FullTextXML).ToLower
        Dim index1 As Integer = S.IndexOf("pressure")
        Dim NewStr As String = S.Substring(index1)
        Dim index2 As Integer = NewStr.IndexOf(" ")
        Dim ss As String = NewStr.Substring(0, index2)
        Dim arr() As String = ss.Split("=")
        Return arr(1).Replace("""", "")
    End Function

    Function Rising() As String
        Dim S As String = GetAtmosphere(FullTextXML).ToLower
        Dim index1 As Integer = S.IndexOf("rising")
        Dim NewStr As String = S.Substring(index1)
        Dim index2 As Integer = NewStr.IndexOf(" ")
        Dim ss As String = NewStr.Substring(0, index2)
        Dim arr() As String = ss.Split("=")
        Select Case arr(1).Replace("""", "")
            Case "0"
                Return "Không đổi"
            Case "1"
                Return "Tăng"
            Case "2"
                Return "Giảm"
            Case Else
                Return "NULL"
        End Select
    End Function

    Function Status() As String
        Dim T As String = GetCondition(FullTextXML)
        Dim index1 As Integer = T.IndexOf("text")
        Dim NewStr As String = T.Substring(index1)
        Dim index2 As Integer = NewStr.IndexOf(" code")
        Dim ss As String = NewStr.Substring(0, index2)
        Dim arr() As String = ss.Split("=")
        Return arr(1).Replace("""", "") + "."
    End Function

    Function Temp() As String
        Dim T As String = GetCondition(FullTextXML).ToLower
        Dim index1 As Integer = T.IndexOf("temp")
        Dim NewStr As String = T.Substring(index1)
        Dim index2 As Integer = NewStr.IndexOf(" ")
        Dim ss As String = NewStr.Substring(0, index2)
        Dim arr() As String = ss.Split("=")
        Return arr(1).Replace("""", "")
    End Function

    Function LastBuilData() As String
        Return LastBuilData(FullTextXML)
    End Function

    Function Delete(ByVal filename As String) As Boolean
        Try
            IO.File.Delete(filename)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function getXML() As String
        Return FullTextXML
    End Function

    Function GetImage() As String
        ' MsgBox((Regex.Match(TextXML, "\s*=\s*(?:""(?<1>[^""]*)""|(?<1>\S+))").Value.Split("=")(1).Replace("""", "")))
        Dim str As String = (Regex.Match(PartTextXML, "\s*=\s*(?:""(?<1>[^""]*)""|(?<1>\S+))").Value.Split("=")(1).Replace("""", ""))
        Dim Dir As String
        Dim filePic As String
        Dir = My.Computer.FileSystem.SpecialDirectories.Temp
        Dim d As New Net.WebClient
        filePic = Dir & "\" & IO.Path.GetFileName(str)
        If IO.File.Exists(filePic) Then
            If Delete(filePic) Then
                d.DownloadFile(str, filePic)
            End If
        Else
            d.DownloadFile(str, filePic)
        End If
        Return (filePic)
    End Function

    Function City() As String
        Dim str As String = location(FullTextXML)
        Dim index1 As Integer = str.IndexOf("city")
        Dim newstr As String = str.Substring(index1)
        Dim index2 As Integer = newstr.IndexOf(" region")
        Dim ss As String = newstr.Substring(0, index2)
        Dim arr() As String = ss.Split("=")
        Return arr(1).Replace("""", "")
    End Function

    Function Country() As String
        Dim str As String = location(FullTextXML)
        Dim index1 As Integer = str.IndexOf("country")
        Dim newstr As String = str.Substring(index1)
        Dim index2 As Integer = newstr.IndexOf(" ")
        Dim ss As String = newstr.Substring(0, index2)
        Dim arr() As String = ss.Split("=")
        Return arr(1).Replace("""", "")
    End Function
End Class
