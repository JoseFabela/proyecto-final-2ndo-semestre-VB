Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Security.Cryptography
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports AForge.Video.DirectShow
Imports AForge.Video
Imports System.Runtime.InteropServices
Imports System.Net.Mime.MediaTypeNames
Imports Emgu.CV
Imports Emgu.CV.Structure
Imports System.Drawing.Imaging

Imports Emgu.CV
Imports Emgu.Util
Imports Emgu.CV.Structure
Imports Emgu.CV.CvEnum
Imports System.Data.SqlClient
Public Class Registrarse
    Private Sub Registrarse_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private connection As New SqlConnection("Data source = localhost;Initial Catalog=Inventario;Integrated Security= True")
    Private connectionString As String = "Data Source=localhost;Initial Catalog=Inventario;Integrated Security= True"

    Public Sub New()
        InitializeComponent()
        FormBorderStyle = FormBorderStyle.None
    End Sub

    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        Dim usuario As String = textUser.Text
        Dim contraseña As String = textPassword.Text
        Dim confirmpassword As String = txtConfirmPassword.Text

        If String.IsNullOrWhiteSpace(usuario) OrElse String.IsNullOrWhiteSpace(contraseña) Then
            MessageBox.Show("Please enter a valid username and password.")
            Return
        End If

        If contraseña = confirmpassword Then
            Dim cadenaConexion As String = "Data Source=localhost;Initial Catalog=Inventario;Integrated Security= True"
            Dim consultaExistencia As String = "SELECT COUNT(*) FROM Usuarios WHERE Username = @Username"

            Using connection As New SqlConnection(cadenaConexion)
                connection.Open()

                Using command As New SqlCommand(consultaExistencia, connection)
                    command.Parameters.AddWithValue("@Username", usuario)

                    Dim existencia As Integer = Convert.ToInt32(command.ExecuteScalar())

                    If existencia > 0 Then
                        MessageBox.Show("User already exists. Please choose another username.")
                        Return
                    End If
                End Using

                Dim consultaRegistro As String = "INSERT INTO Usuarios (Username, Password) VALUES (@Username, @Password)"

                Using commandRegistro As New SqlCommand(consultaRegistro, connection)
                    commandRegistro.Parameters.AddWithValue("@Username", usuario)
                    commandRegistro.Parameters.AddWithValue("@Password", contraseña)

                    commandRegistro.ExecuteNonQuery()
                End Using

                connection.Close()
            End Using

            MessageBox.Show("Successful registration. Now you can login.")
            textUser.Clear()
            textPassword.Clear()
            txtConfirmPassword.Clear()
        Else
            MessageBox.Show("The passwords are not the same")
        End If
    End Sub

    Private Sub linkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLabel1.LinkClicked
        Dim inicio_De_Sesion As New Form1()
        inicio_De_Sesion.ShowDialog()
        Me.Hide()
    End Sub



End Class