Imports Castle.DynamicProxy.Generators.Emitters.SimpleAST
Imports Keras
Imports Newtonsoft.Json.Linq
Imports OpenTK
Imports OpenTK.Audio.OpenAL
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports System.Xml.Linq
Imports Proyecto_final_2ndo_semestre_c_sharp.Usuario
Imports System.Data.SqlClient
Imports System.Net.PeerToPeer
Imports proyecto_final_2ndo_semestre_VB.Usuarios

Public Class INVENTARIO

    Private connection As New SqlConnection("Data source = localhost;Initial Catalog=Inventario;Integrated Security= True")
    Private connectionString As String = "Data Source=localhost;Initial Catalog=Inventario;Integrated Security= True"
    Private nombreUsuario As String

    Public Sub New(ByVal nombreUsuario As String)
        'Add the columns To the Table
        InitializeComponent()
        Me.nombreUsuario = nombreUsuario

        FormBorderStyle = FormBorderStyle.None 'This line sets the form's border style to None, which means that the form will have no border.
        Me.pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage 'This line sets the PictureBox control named pictureBox1 to display the image in the center.
        'If the image is smaller than the PictureBox size, it will be displayed in the center of the PictureBox.

        Me.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom 'This line sets the PictureBox control named pictureBox1 to display the image by zooming it to fit
        'within the PictureBox bounds.The aspect ratio of the image will be preserved, and the image will be resized to completely fit within the PictureBox.
    End Sub
    Private Sub pictureBox1_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)
        Dim graphicsPath As New GraphicsPath()
        graphicsPath.AddEllipse(0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1)
        pictureBox1.Region = New Region(graphicsPath)
    End Sub

    Private Function ObtenerNombreUsuario() As String
        ' Supongamos que tienes una variable global llamada 'usuarioActual'
        ' que almacena el nombre de usuario del usuario que ha iniciado sesión correctamente
        Return nombreUsuario
    End Function

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        AddHandler pictureBox1.Paint, AddressOf pictureBox1_Paint
        Dim nombreUsuario As String = ObtenerNombreUsuario() ' Reemplaza con el nombre de usuario correspondiente

        MostrarImagenPerfil(nombreUsuario)
    End Sub

    Private Sub Delete(ByVal id As Integer)
        Dim eliminar As New SqlCommand("DELETE FROM inventarioDatos WHERE Id = @Id", connection)
        connection.Open()
        Try
            eliminar.Parameters.AddWithValue("@Id", id)
            Dim rowsAffected As Integer = eliminar.ExecuteNonQuery()
            If rowsAffected > 0 Then
                MessageBox.Show("Registro eliminado correctamente")
                ' Actualizar el DataGridView si es necesario
            Else
                MessageBox.Show("No se encontró el registro con el ID especificado")
            End If
        Catch ex As Exception
            MessageBox.Show("Error al eliminar el registro: " & ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub
    Private Sub Add()
        Dim agregar As New SqlCommand("insert into inventarioDatos values (@Name, @Price, @Quantity)", connection)
        connection.Open()
        Dim Name As String = txtNombreDeProducto.Text
        Dim Price As Decimal = Decimal.Parse(txtPrecioDelProducto.Text)
        Dim Quantity As Integer = Integer.Parse(txtCantidadDelProducto.Text)
        Try
            agregar.Parameters.Clear()
            If Name IsNot Nothing AndAlso Price > 0 AndAlso Quantity > 0 Then
                agregar.Parameters.AddWithValue("@Name", Name)
                agregar.Parameters.AddWithValue("@Price", Price.ToString())
                agregar.Parameters.AddWithValue("@Quantity", Quantity.ToString())
                agregar.ExecuteNonQuery()
            End If
            MessageBox.Show("Datos agregados")
        Catch ex As Exception
            MessageBox.Show("Error al agregar")
        Finally
            connection.Close()
        End Try
    End Sub


    Private selectedId As Nullable(Of Integer) ' Variable para almacenar el ID seleccionado

    Private Sub CellContentDTGPRODUCT(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)

    End Sub




    Private Sub GuardarRutaImagenEnSQL(ByVal rutaImagen As String, ByVal nombreUsuario As String)
        ' Realizar la conexión a la base de datos y ejecutar la consulta SQL para guardar la ruta de la imagen
        Using connection As New SqlConnection(connectionString)
            Dim consulta As String = "UPDATE Usuarios SET Picture = @Picture WHERE Username = @Username"
            Dim command As New SqlCommand(consulta, connection)
            command.Parameters.AddWithValue("@Picture", rutaImagen)
            command.Parameters.AddWithValue("@Username", nombreUsuario)

            connection.Open()
            command.ExecuteNonQuery()
        End Using
    End Sub


    Public Sub MostrarImagenPerfil(ByVal username As String)
        ' Realizar la conexión a la base de datos y ejecutar la consulta SQL para obtener los datos de la imagen
        Using connection As New SqlConnection(connectionString)
            Dim consulta As String = "SELECT Picture FROM Usuarios WHERE Username = @Username"
            Dim command As New SqlCommand(consulta, connection)
            command.Parameters.AddWithValue("@Username", username)

            connection.Open()
            Dim rutaImagen As String = Convert.ToString(command.ExecuteScalar())

            If Not String.IsNullOrEmpty(rutaImagen) Then
                Try
                    pictureBox1.Image = Image.FromFile(rutaImagen)
                Catch ex As Exception
                    'MessageBox.Show("Error al cargar la imagen: " & ex.Message)
                End Try
            Else
                ' Ruta de la imagen predeterminada
                Dim rutaImagenPredeterminada As String = "C:\Users\junio\OneDrive\Imágenes\vector-de-perfil-avatar-predeterminado-foto-usuario-medios-sociales-icono-183042379.jpg"

                ' Verificar si la imagen predeterminada existe en la ruta especificada
                If File.Exists(rutaImagenPredeterminada) Then
                    pictureBox1.Image = Image.FromFile(rutaImagenPredeterminada)
                End If
            End If
        End Using
    End Sub
    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    ' This is a method named "CerrarSesion" (Logout) that performs the logic to log out the user.
    Public Sub CerrarSesion()
        ' Código para cerrar sesión
        ' ...

        'The code for logging out is not shown and should be implemented as per the specific requirements of the application.

        ' Redirigir al formulario de inicio de sesión
        'After the user is logged out, a new instance of the "Inicio_de_sesion" (Login) form is created.
        Dim formInicioSesion As New Form1()

        'The "Inicio_de_sesion" form is displayed using the Show method, and the current form is hidden using the Hide method.
        formInicioSesion.Show()
        Me.Hide()
    End Sub
    Private Sub btnSQL_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Public Sub ShowSqlTable()
        ' Realizar una consulta SQL para obtener los datos del inventario
        Dim query As String = "SELECT * FROM inventarioDatos"
        Dim command As New SqlCommand(query, connection)
        Dim dataAdapter As New SqlDataAdapter(command)
        Dim dataTable As New DataTable()

        Try
            connection.Open()

            ' Rellenar el DataTable con los datos del inventario
            dataAdapter.Fill(dataTable)

            ' Asignar el DataTable al DataGridView para mostrar los datos del inventario
            dtgProduct.DataSource = dataTable
        Catch ex As Exception
            MessageBox.Show("Error al mostrar el inventario: " & ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub


    Private Sub BTNSHOWINVENTARIO_Click(sender As Object, e As EventArgs) Handles BTNSHOWINVENTARIO.Click
        ShowSqlTable()

    End Sub

    Private Sub btnAdd_Click_1(sender As Object, e As EventArgs) Handles btnAdd.Click
        Add()
    End Sub

    Private Sub btnDelete_Click_1(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedId.HasValue Then
            Delete(selectedId.Value)
        Else
            MessageBox.Show("Select the name of the product to proceed to delete")
        End If
    End Sub

    Private Sub btnEdit_Click_1(sender As Object, e As EventArgs) Handles btnEdit.Click
        Edit()
    End Sub
    Private Sub Edit()
        ' Obtén los nuevos valores del nombre, precio y cantidad desde los TextBox
        Dim newName As String = txtNombreDeProducto.Text
        Dim newPrice As Decimal = Decimal.Parse(txtPrecioDelProducto.Text)
        Dim newQuantity As Integer = Integer.Parse(txtCantidadDelProducto.Text)

        Using connection As New SqlConnection(connectionString)
            Dim editar As New SqlCommand("UPDATE inventarioDatos SET Name = @NewName, Price = @NewPrice, Quantity = @NewQuantity WHERE Id = @Id", connection)
            editar.Parameters.AddWithValue("@NewName", newName)
            editar.Parameters.AddWithValue("@NewPrice", newPrice)
            editar.Parameters.AddWithValue("@NewQuantity", newQuantity)
            editar.Parameters.AddWithValue("@Id", selectedId) ' Utiliza el valor de selectedId en el parámetro @Id

            Try
                connection.Open()
                Dim rowsAffected As Integer = editar.ExecuteNonQuery()
                If rowsAffected > 0 Then
                    MessageBox.Show("Registro actualizado correctamente")
                Else
                    MessageBox.Show("No se encontró el registro")
                End If
            Catch ex As Exception
                MessageBox.Show("Error al editar el registro")
            Finally
                connection.Close()
            End Try
        End Using
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
        Me.Close()
    End Sub

    Private Sub btnModificarUsuario_Click_1(sender As Object, e As EventArgs) Handles btnModificarUsuario.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif|Todos los archivos|*.*"
        openFileDialog.Title = "Seleccionar imagen"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim rutaImagen As String = openFileDialog.FileName
            ' Ajustar la ruta de la imagen para manejar caracteres especiales y barras invertidas
            ' Codificar la ruta de la imagen

            ' Guardar la ruta de la imagen en la base de datos
            GuardarRutaImagenEnSQL(rutaImagen, nombreUsuario)

            ' Mostrar la imagen en el PictureBox
            pictureBox1.Image = Image.FromFile(rutaImagen)
        End If

    End Sub

    Private Sub INVENTARIO_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub button1_Click_1(sender As Object, e As EventArgs) Handles button1.Click
        Dim camara As New Camara(nombreUsuario)
        camara.ShowDialog()

    End Sub

    Private Sub btnSignOff_Click(sender As Object, e As EventArgs) Handles btnSignOff.Click
        ' Llamar al método de la interfaz para cerrar sesión
        Dim cerrarSesion As ICerrarSesion = Me
        ' La interfaz ICerrarSesion se asume implementada por el formulario actual o uno de sus formularios padre, permitiendo acceder
        ' al método "CerrarSesion".
        cerrarSesion.CerrarSesion()


    End Sub
End Class