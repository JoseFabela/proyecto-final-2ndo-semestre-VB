Imports Accord.Statistics.Kernels
Imports AForge.Video
Imports AForge.Video.DirectShow
Imports Python.Runtime
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Dynamic
Imports System.IO
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Proyecto_final_2ndo_semestre_c_sharp.Usuario
Imports System.Net.WebRequestMethods
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports System.Data.SqlClient

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dispositivosVideo As FilterInfoCollection = New FilterInfoCollection(FilterCategory.VideoInputDevice)

        If dispositivosVideo.Count > 0 Then
            fuenteVideo = New VideoCaptureDevice(dispositivosVideo(0).MonikerString)
            AddHandler fuenteVideo.NewFrame, AddressOf CapturarFrame
        Else
            MessageBox.Show("No se encontraron dispositivos de captura de video.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private connection As SqlConnection = New SqlConnection("Data source = localhost;Initial Catalog=Inventario;Integrated Security= True")
    Private connectionString As String = "Data Source=localhost;Initial Catalog=Inventario;Integrated Security= True"
    Private intentosFallidos As Integer = 0
    Private usuario As String
    Private dispositivos As FilterInfoCollection
    Private fuenteVideo As VideoCaptureDevice
    Private fotogramaActual As Bitmap

    Private Const MaximoIntentosFallidos As Integer = 3

    Public Sub New()
        InitializeComponent()
        dispositivos = New FilterInfoCollection(FilterCategory.VideoInputDevice)
        fuenteVideo = New VideoCaptureDevice(dispositivos(0).MonikerString)
        FormBorderStyle = FormBorderStyle.None
    End Sub



    Private Sub LblRegistrarse_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LblRegistrarse.LinkClicked
        Dim registrarse As Registrarse = New Registrarse()
        registrarse.ShowDialog()
        Me.Hide()
    End Sub

    Private Sub CapturarFrame(sender As Object, eventArgs As NewFrameEventArgs)
        fotogramaActual = CType(eventArgs.Frame.Clone(), Bitmap)
    End Sub

    Private Function VerificarCredenciales(usuario As String, contraseña As String) As Boolean
        Dim consulta As String = "SELECT COUNT(*) FROM Usuarios WHERE Username = @Usuario AND Password = @Contraseña"

        Using connection As SqlConnection = New SqlConnection(connectionString)
            Dim command As SqlCommand = New SqlCommand(consulta, connection)
            command.Parameters.AddWithValue("@Usuario", usuario)
            command.Parameters.AddWithValue("@Contraseña", contraseña)

            connection.Open()
            Dim existencia As Integer = Convert.ToInt32(command.ExecuteScalar())
            Return existencia > 0
        End Using
    End Function

    Private Sub BtnLogIn_Click(sender As Object, e As EventArgs) Handles BtnLogIn.Click
        Dim username As String = txtUser.Text
        Dim password As String = txtPassword.Text
        Dim nombreUsuario As String = txtUser.Text
        nombreUsuario = nombreUsuario

        ' Verificar si el usuario y la contraseña coinciden en la base de datos
        Dim inicioSesionExitoso As Boolean = VerificarCredenciales(username, password)

        If inicioSesionExitoso Then
            ' Inicio de sesión exitoso, abrir el Form1
            Dim inventoryForm As New INVENTARIO(nombreUsuario)
            inventoryForm.Show()
            Dim camara As New Camara(nombreUsuario)
            MessageBox.Show("Inicio de sesión exitoso")

            ' Ocultar el formulario actual (Inicio_de_sesion)
            Me.Hide()
        Else
            MessageBox.Show("El usuario no existe o la contraseña es incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            ' Incrementar el contador de intentos fallidos
            intentosFallidos += 1

            If intentosFallidos = MaximoIntentosFallidos Then
                ' Si se alcanza el número máximo de intentos fallidos, llamar al método TomarFoto
                TomarFoto(usuario)
            End If
        End If
    End Sub
    Private Sub TomarFoto(username As String)
        ' Iniciar la captura de video desde la cámara (fuenteVideo.Start())
        fuenteVideo.Start()

        ' Capturar el fotograma actual
        ' Esperar 4 segundos antes de tomar la foto (opcional)
        Thread.Sleep(4000)

        ' Clonar el fotograma actual en un objeto Bitmap llamado fotograma
        Dim fotograma As Bitmap = DirectCast(fotogramaActual.Clone(), Bitmap)

        ' Detener la cámara (fuenteVideo.Stop())
        fuenteVideo.Stop()

        ' Capturar el último fotograma
        If fotogramaActual IsNot Nothing Then
            ' Obtener la fecha actual para generar un nombre de archivo único
            Dim fecha As String = DateTime.Now.ToString("yyyyMMddHHmmss")
            Dim nombreArchivo As String = $"Foto_{username}_{fecha}.jpg"

            ' Obtener la ruta del escritorio
            Dim rutaEscritorio As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

            ' Crear la ruta completa para guardar la foto
            Dim rutaCompleta As String = Path.Combine(rutaEscritorio, nombreArchivo)

            ' Guardar la imagen en formato JPEG en la ruta especificada
            fotogramaActual.Save(rutaCompleta, System.Drawing.Imaging.ImageFormat.Jpeg)
        End If
    End Sub

End Class
