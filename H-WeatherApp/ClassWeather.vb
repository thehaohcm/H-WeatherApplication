Imports System.Web.RegularExpressions
Imports System.Text.RegularExpressions
Imports H_WeatherApp

Public Class ClassWeather
    Inherits H_Weather
    Sub New(ByVal U As String, ByVal P As String)
        MyBase.New(U, P)
    End Sub

    Function FCTomorrow() As String
        Dim T() As String = FCstr().Split("<br />")
        Return T(0).Substring(1)
    End Function

    Function FCNextDay() As String
        Dim T() As String = FCstr().Split("<br />")
        Dim st As String = T(1)
        Dim index1 As Integer = st.IndexOf("br />") + Len("br />")
        Dim s2 As String = st.Substring(index1)
        Return s2.Substring(1)
    End Function

    Function FCNextToDay() As String
        Dim T() As String = FCstr().Split("<br />")
        Dim st As String = T(2)
        Dim index1 As Integer = st.IndexOf("br />") + Len("br />")
        Dim s3 As String = st.Substring(index1)
        Return s3.Substring(1)
    End Function

    Function Thu(ByVal str As String) As String
        Select Case str
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

    Function Low_Tomorrow() As String
        Dim T() As String = FCTomorrow.Split(" ")
        If T.Length = 7 Then
            Return T(6)
        Else
            Return T(7)
        End If

    End Function

    Function High_Tomorrow() As String
        Dim T() As String = FCTomorrow.Split(" ")
        If T.Length = 7 Then
            Return T(4)
        Else
            Return T(5)
        End If
    End Function

    Function Stt_Tomorrow() As String
        Dim T() As String = FCTomorrow.Split(" ")
        If T.Length = 8 Then
            Return T(2) + " " + T(3)
        Else
            Return T(2)
        End If

    End Function

    Function Thu_Tomorrow() As String
        Dim T() As String = FCTomorrow.Split(" ")

        Return Thu(T(0))
    End Function

    Function Low_NextDay() As String
        Dim T() As String = FCNextDay.Split(" ")
        If T.Length = 7 Then
            Return T(6)
        Else
            Return T(7)
        End If
    End Function

    Function High_NextDay() As String
        Dim T() As String = FCNextDay.Split(" ")
        If T.Length = 7 Then
            Return T(4)
        Else
            Return T(5)
        End If
    End Function

    Function Stt_NextDay() As String
        Dim T() As String = FCNextDay.Split(" ")
        If T.Length = 8 Then
            Return T(2) + " " + T(3)
        Else
            Return T(2)
        End If
    End Function

    Function Thu_NextDay() As String
        Dim T() As String = FCNextDay.Split(" ")
        Return Thu(T(0))
    End Function

    Function Low_NextToDay() As String
        Dim T() As String = FCNextToDay.Split(" ")
        If T.Length = 7 Then
            Return T(6)
        Else
            Return T(7)
        End If
    End Function

    Function High_NextToDay() As String
        Dim T() As String = FCNextToDay.Split(" ")
        If T.Length = 7 Then
            Return T(4)
        Else
            Return T(5)
        End If
    End Function

    Function Stt_NextToDay() As String
        Dim T() As String = FCNextToDay.Split(" ")
        If T.Length = 8 Then
            Return T(2) + " " + T(3)
        Else
            Return T(2)
        End If
    End Function

    Function Thu_NextToDay() As String
        Dim T() As String = FCNextToDay.Split(" ")
        Return Thu(T(0))
    End Function

    Function testNextToDay() As String
        Dim T() As String = FCNextToDay.Split(" ")
        Return T.Length
    End Function
    Function testTomorrow() As String
        Dim T() As String = FCTomorrow.Split(" ")
        Return T.Length

    End Function
End Class
