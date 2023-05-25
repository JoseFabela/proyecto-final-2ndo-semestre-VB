<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class INVENTARIO
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.label5 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.BTNSHOWINVENTARIO = New System.Windows.Forms.Button()
        Me.btnSQL = New System.Windows.Forms.Button()
        Me.btnSignOff = New System.Windows.Forms.Button()
        Me.button1 = New System.Windows.Forms.Button()
        Me.btnModificarUsuario = New System.Windows.Forms.Button()
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnOpenArchieve = New System.Windows.Forms.Button()
        Me.dtgProduct = New System.Windows.Forms.DataGridView()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txtPrecioDelProducto = New System.Windows.Forms.TextBox()
        Me.txtCantidadDelProducto = New System.Windows.Forms.TextBox()
        Me.txtNombreDeProducto = New System.Windows.Forms.TextBox()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'label5
        '
        Me.label5.BackColor = System.Drawing.Color.White
        Me.label5.Location = New System.Drawing.Point(444, 22)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(137, 42)
        Me.label5.TabIndex = 41
        Me.label5.Text = "Select the price, and fill in the fields of the object you want to edit"
        '
        'label4
        '
        Me.label4.BackColor = System.Drawing.Color.White
        Me.label4.Location = New System.Drawing.Point(308, 22)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(105, 42)
        Me.label4.TabIndex = 40
        Me.label4.Text = "Select de name of the product to delete"
        '
        'BTNSHOWINVENTARIO
        '
        Me.BTNSHOWINVENTARIO.BackColor = System.Drawing.Color.Red
        Me.BTNSHOWINVENTARIO.Location = New System.Drawing.Point(590, 69)
        Me.BTNSHOWINVENTARIO.Name = "BTNSHOWINVENTARIO"
        Me.BTNSHOWINVENTARIO.Size = New System.Drawing.Size(93, 23)
        Me.BTNSHOWINVENTARIO.TabIndex = 39
        Me.BTNSHOWINVENTARIO.Text = "Show inventario"
        Me.BTNSHOWINVENTARIO.UseVisualStyleBackColor = False
        '
        'btnSQL
        '
        Me.btnSQL.BackColor = System.Drawing.Color.Red
        Me.btnSQL.Location = New System.Drawing.Point(703, 69)
        Me.btnSQL.Name = "btnSQL"
        Me.btnSQL.Size = New System.Drawing.Size(75, 23)
        Me.btnSQL.TabIndex = 38
        Me.btnSQL.Text = "SQL"
        Me.btnSQL.UseVisualStyleBackColor = False
        '
        'btnSignOff
        '
        Me.btnSignOff.Location = New System.Drawing.Point(226, 406)
        Me.btnSignOff.Name = "btnSignOff"
        Me.btnSignOff.Size = New System.Drawing.Size(75, 23)
        Me.btnSignOff.TabIndex = 37
        Me.btnSignOff.Text = "Sign Off"
        Me.btnSignOff.UseVisualStyleBackColor = True
        '
        'button1
        '
        Me.button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.button1.Location = New System.Drawing.Point(92, 126)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(68, 25)
        Me.button1.TabIndex = 36
        Me.button1.Text = "Take picture"
        Me.button1.UseVisualStyleBackColor = True
        '
        'btnModificarUsuario
        '
        Me.btnModificarUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModificarUsuario.Location = New System.Drawing.Point(11, 126)
        Me.btnModificarUsuario.Name = "btnModificarUsuario"
        Me.btnModificarUsuario.Size = New System.Drawing.Size(68, 25)
        Me.btnModificarUsuario.TabIndex = 35
        Me.btnModificarUsuario.Text = "Add picture"
        Me.btnModificarUsuario.UseVisualStyleBackColor = True
        '
        'pictureBox1
        '
        Me.pictureBox1.Location = New System.Drawing.Point(33, 22)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(102, 98)
        Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictureBox1.TabIndex = 34
        Me.pictureBox1.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(11, 406)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 33
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.Red
        Me.btnSave.Location = New System.Drawing.Point(590, 31)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 32
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnOpenArchieve
        '
        Me.btnOpenArchieve.BackColor = System.Drawing.Color.Red
        Me.btnOpenArchieve.Location = New System.Drawing.Point(703, 31)
        Me.btnOpenArchieve.Name = "btnOpenArchieve"
        Me.btnOpenArchieve.Size = New System.Drawing.Size(75, 23)
        Me.btnOpenArchieve.TabIndex = 31
        Me.btnOpenArchieve.Text = "Open File"
        Me.btnOpenArchieve.UseVisualStyleBackColor = False
        '
        'dtgProduct
        '
        Me.dtgProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgProduct.Location = New System.Drawing.Point(322, 98)
        Me.dtgProduct.Name = "dtgProduct"
        Me.dtgProduct.Size = New System.Drawing.Size(467, 331)
        Me.dtgProduct.TabIndex = 30
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.label3.Location = New System.Drawing.Point(13, 284)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(86, 13)
        Me.label3.TabIndex = 29
        Me.label3.Text = "Product Quantity"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.label2.Location = New System.Drawing.Point(13, 224)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(100, 13)
        Me.label2.TabIndex = 28
        Me.label2.Text = "Price of the product"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.label1.Location = New System.Drawing.Point(13, 173)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(73, 13)
        Me.label1.TabIndex = 27
        Me.label1.Text = "Product name"
        '
        'txtPrecioDelProducto
        '
        Me.txtPrecioDelProducto.Location = New System.Drawing.Point(81, 254)
        Me.txtPrecioDelProducto.Name = "txtPrecioDelProducto"
        Me.txtPrecioDelProducto.Size = New System.Drawing.Size(183, 20)
        Me.txtPrecioDelProducto.TabIndex = 26
        '
        'txtCantidadDelProducto
        '
        Me.txtCantidadDelProducto.Location = New System.Drawing.Point(81, 308)
        Me.txtCantidadDelProducto.Name = "txtCantidadDelProducto"
        Me.txtCantidadDelProducto.Size = New System.Drawing.Size(183, 20)
        Me.txtCantidadDelProducto.TabIndex = 25
        '
        'txtNombreDeProducto
        '
        Me.txtNombreDeProducto.Location = New System.Drawing.Point(81, 189)
        Me.txtNombreDeProducto.Name = "txtNombreDeProducto"
        Me.txtNombreDeProducto.Size = New System.Drawing.Size(183, 20)
        Me.txtNombreDeProducto.TabIndex = 24
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnEdit.Location = New System.Drawing.Point(447, 67)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 23
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnDelete.Location = New System.Drawing.Point(338, 67)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 22
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnAdd.Location = New System.Drawing.Point(226, 69)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 21
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'INVENTARIO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.BTNSHOWINVENTARIO)
        Me.Controls.Add(Me.btnSQL)
        Me.Controls.Add(Me.btnSignOff)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.btnModificarUsuario)
        Me.Controls.Add(Me.pictureBox1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnOpenArchieve)
        Me.Controls.Add(Me.dtgProduct)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.txtPrecioDelProducto)
        Me.Controls.Add(Me.txtCantidadDelProducto)
        Me.Controls.Add(Me.txtNombreDeProducto)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Name = "INVENTARIO"
        Me.Text = "INVENTARIO"
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgProduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents label5 As Label
    Private WithEvents label4 As Label
    Private WithEvents BTNSHOWINVENTARIO As Button
    Private WithEvents btnSQL As Button
    Private WithEvents btnSignOff As Button
    Private WithEvents button1 As Button
    Private WithEvents btnModificarUsuario As Button
    Private WithEvents pictureBox1 As PictureBox
    Private WithEvents btnExit As Button
    Private WithEvents btnSave As Button
    Private WithEvents btnOpenArchieve As Button
    Private WithEvents dtgProduct As DataGridView
    Private WithEvents label3 As Label
    Private WithEvents label2 As Label
    Private WithEvents label1 As Label
    Private WithEvents txtPrecioDelProducto As TextBox
    Private WithEvents txtCantidadDelProducto As TextBox
    Private WithEvents txtNombreDeProducto As TextBox
    Private WithEvents btnEdit As Button
    Private WithEvents btnDelete As Button
    Private WithEvents btnAdd As Button
End Class
