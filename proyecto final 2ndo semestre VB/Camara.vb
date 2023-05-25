Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports AForge.Video
Imports AForge.Video.DirectShow
Imports System.Drawing.Imaging
Imports System.Threading
Public Class Camara
    Private Sub Camara_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'videoSource.Start() is called to start capturing video from the video source.
        videoSource.Start()

    End Sub
    'This code defines a delegate named FotoTomadaEventHandler, which represents the signature of an event handler method that takes an object sender and an
    'Image foto as parameters and does not return a value.
    Public Delegate Sub FotoTomadaEventHandler(ByVal sender As Object, ByVal foto As Image)

    Public Event FotoTomada As FotoTomadaEventHandler 'The FotoTomada event is declared using the FotoTomadaEventHandler delegate. This event can be raised when a photo is taken,
    'and it allows other code to subscribe to the event and be notified when it occurs.

    Private videoDevices As FilterInfoCollection 'videoDevices is a variable that holds a collection of available video devices. It is of type FilterInfoCollection,
    'which is typically used to store information about video capture devices.

    Private WithEvents videoSource As VideoCaptureDevice
    'videoSource is a variable that represents the selected video capture device. It is of type VideoCaptureDevice.
    Private fotogramaActual As Bitmap 'fotogramaActual is a variable that holds the current frame or snapshot captured from the video source. It is of type Bitmap.

    'This is the constructor method for the Camara class.
    Private nombreUsuario As String

    Public Sub New(ByVal nombreUsuario As String)
        'InitializeComponent() is called to initialize the components of the form associated with the Camara class.
        InitializeComponent()

        'The pictureBox1.SizeMode property is set to PictureBoxSizeMode.CenterImage and then immediately set to PictureBoxSizeMode.Zoom.
        'This may be redundant or unintended.
        Me.nombreUsuario = nombreUsuario
        Me.pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage
        Me.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom

        'FormBorderStyle is set to FormBorderStyle.None, which removes the form's title bar and borders.
        FormBorderStyle = FormBorderStyle.None

        'videoDevices is initialized with a collection of available video input devices using FilterInfoCollection and FilterCategory.VideoInputDevice.
        videoDevices = New FilterInfoCollection(FilterCategory.VideoInputDevice)

        'videoSource is initialized with the selected video input device using VideoCaptureDevice and the first device in the videoDevices collection.
        videoSource = New VideoCaptureDevice(videoDevices(0).MonikerString)

        'An event handler, CapturarFrame, is assigned to the NewFrame event of the videoSource to capture new frames from the video source.
        AddHandler videoSource.NewFrame, AddressOf CapturarFrame

        'temporizador is initialized as a Timer object with an interval of 5000 milliseconds (5 seconds).

    End Sub
    Private Sub btnCapture_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCapture.Click
        'temporizador.Start() is called to start the timer.
        'videoSource.SignalToStop() is called to signal the video source to stop capturing frames.
        ' Detener la cámara
        videoSource.SignalToStop()
        'videoSource.WaitForStop() is called to wait until the video source stops capturing frames.
        videoSource.WaitForStop()
        'TomarFoto() is called to capture the photo.
        ' Tomar la foto
        TomarFoto()
        'this.Close() is called to close the form.
        ' Cerrar el formulario
        Me.Close()
        'temporizador.Start()
    End Sub
    Private Sub videoSource_NewFrame(ByVal sender As Object, ByVal eventArgs As NewFrameEventArgs) Handles videoSource.NewFrame
        'The new frame is cloned and assigned to the pictureBox1.Image property to display it in the PictureBox control.
        ' Muestra el nuevo fotograma en el control PictureBox
        pictureBox1.Image = DirectCast(eventArgs.Frame.Clone(), Bitmap)
    End Sub

    'The btnClose_Click event handler is triggered when the "Close" button is clicked.

    Private Sub TomarFoto()
        'If fotogramaActual is not null (a frame has been captured), the frame is saved as a Jpeg image at the specified rutaImagen.
        If fotogramaActual IsNot Nothing Then
            Dim rutaImagen As String = "C:\Users\junio\OneDrive\Imágenes\camara\" & nombreUsuario & "_" & DateTime.Now.ToString("yyyyMMddHHmmss") & ".jpeg"
            Try
                fotogramaActual.Save(rutaImagen, Imaging.ImageFormat.Jpeg)
            Catch ex As Exception
                MessageBox.Show("Error al guardar la imagen: " & ex.Message)
            End Try
        End If
    End Sub

    'The CapturarFrame event handler is triggered when a new frame is captured from the video source.

    Private Sub CapturarFrame(ByVal sender As Object, ByVal eventArgs As NewFrameEventArgs) Handles videoSource.NewFrame
        ' El nuevo fotograma se clona y se asigna a la variable fotogramaActual
        fotogramaActual = DirectCast(eventArgs.Frame.Clone(), Bitmap)
        ' Mostrar el fotograma en el control PictureBox
        pictureBox1.Image = fotogramaActual
    End Sub

End Class