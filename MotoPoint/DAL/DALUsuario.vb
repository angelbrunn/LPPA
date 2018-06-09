Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data.Common
Imports BE
Imports EL

Namespace SIS.DATOS
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class DALUsuario
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function obtenerUltimoId() As Integer
            Dim ultimoId As Integer

            Dim conexString As String = System.Configuration.ConfigurationManager.ConnectionStrings("MotoPoint").ConnectionString
            Dim sqlQuery As String = "SELECT MAX(idUsuario) FROM tbl_Usuario"

            Dim conex As New SqlConnection
            conex.ConnectionString = conexString

            Dim comando As SqlCommand = conex.CreateCommand
            comando.CommandType = CommandType.Text
            comando.CommandText = sqlQuery

            Try
                conex.Open()

                ultimoId = comando.ExecuteScalar

                conex.Close()

            Catch ex As Exception
                Throw New EL.SIS.EXCEPCIONES.DALExcepcion(ex.Message)
            End Try
            Return ultimoId
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="idUsuario"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function obtenerLegajoUsuario(ByVal idUsuario As Integer) As Integer
            Dim legajoVendedor As Integer

            Dim conexString As String = System.Configuration.ConfigurationManager.ConnectionStrings("MotoPoint").ConnectionString
            Dim sqlQuery As String = "SELECT legajo FROM tbl_Usuario WHERE idUsuario=@idUsuario"

            Dim conex As New SqlConnection
            conex.ConnectionString = conexString

            Dim comando As SqlCommand = conex.CreateCommand
            comando.CommandType = CommandType.Text
            comando.CommandText = sqlQuery

            Dim iPar As IDataParameter = comando.CreateParameter
            iPar.ParameterName = "idUsuario"
            iPar.DbType = DbType.Int32
            iPar.Value = idUsuario
            comando.Parameters.Add(iPar)

            Try
                conex.Open()

                legajoVendedor = comando.ExecuteScalar

                conex.Close()

            Catch ex As Exception
            End Try
            Return legajoVendedor
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="idUsuario"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function obtenerUsuarioPorId(ByVal idUsuario As Integer) As BE.SIS.ENTIDAD.Usuario
            Dim oUsuario As New BE.SIS.ENTIDAD.Usuario

            Dim conexString As String = System.Configuration.ConfigurationManager.ConnectionStrings("MotoPoint").ConnectionString
            Dim sqlQuery As String = "SELECT * FROM tbl_Usuario WHERE idUsuario=@idUsuario"

            Dim conex As New SqlConnection
            conex.ConnectionString = conexString

            Dim comando As SqlCommand = conex.CreateCommand
            comando.CommandType = CommandType.Text
            comando.CommandText = sqlQuery

            Dim iPar As IDataParameter = comando.CreateParameter
            iPar.ParameterName = "idUsuario"
            iPar.DbType = DbType.Int32
            iPar.Value = idUsuario
            comando.Parameters.Add(iPar)

            Dim adapter As New SqlDataAdapter(comando)
            Dim ds As New DataSet

            Try
                adapter.Fill(ds, "Usuario")
                Dim dr As DataRow = ds.Tables("Usuario").Rows.Item(0)

                oUsuario.idUsuario = dr("idUsuario")
                oUsuario.usuario = dr("usuario")
                oUsuario.password = dr("password")
                oUsuario.legajo = dr("legajo")
                oUsuario.idioma = dr("idioma")
                oUsuario.digitoVerificador = dr("digitoVerificador")

            Catch ex As Exception
                Throw New EL.SIS.EXCEPCIONES.DALExcepcion("Error en BD", ex)
            End Try
            Return oUsuario
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="legajo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function obtenerUsuarioPorLegajo(ByVal legajo As String) As BE.SIS.ENTIDAD.Usuario
            Dim oUsuario As New BE.SIS.ENTIDAD.Usuario

            Dim conexString As String = System.Configuration.ConfigurationManager.ConnectionStrings("MotoPoint").ConnectionString
            Dim sqlQuery As String = "SELECT * FROM tbl_Usuario WHERE legajo=@legajo"

            Dim conex As New SqlConnection
            conex.ConnectionString = conexString

            Dim comando As SqlCommand = conex.CreateCommand
            comando.CommandType = CommandType.Text
            comando.CommandText = sqlQuery

            Dim iPar As IDataParameter = comando.CreateParameter
            iPar.ParameterName = "legajo"
            iPar.DbType = DbType.String
            iPar.Value = legajo
            comando.Parameters.Add(iPar)

            Dim adapter As New SqlDataAdapter(comando)
            Dim ds As New DataSet

            Try
                adapter.Fill(ds, "Usuario")
                Dim dr As DataRow = ds.Tables("Usuario").Rows.Item(0)

                oUsuario.idUsuario = dr("idUsuario")
                oUsuario.usuario = dr("usuario")
                oUsuario.password = dr("password")
                oUsuario.legajo = dr("legajo")
                oUsuario.idioma = dr("idioma")
                oUsuario.digitoVerificador = dr("digitoVerificador")

            Catch ex As Exception
                Throw New EL.SIS.EXCEPCIONES.DALExcepcion("Error en BD", ex)
            End Try

            Return oUsuario
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="usuario"></param>
        ''' <param name="password"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function validarUsuario(ByVal usuario As String, ByVal password As String) As Integer
            Dim resultadoValidacion As Integer = 0

            Dim conexString As String = System.Configuration.ConfigurationManager.ConnectionStrings("MotoPoint").ConnectionString
            Dim sqlQuery As String = "SELECT [idUsuario] FROM tbl_Usuario WHERE usuario=@usuario AND password=@password"

            Dim conex As New SqlConnection
            conex.ConnectionString = conexString

            Dim comando As SqlCommand = conex.CreateCommand
            comando.CommandType = CommandType.Text
            comando.CommandText = sqlQuery

            Dim iPar As IDataParameter = comando.CreateParameter

            iPar.ParameterName = "usuario"
            iPar.DbType = DbType.String
            iPar.Value = usuario
            comando.Parameters.Add(iPar)

            iPar = comando.CreateParameter
            iPar.ParameterName = "password"
            iPar.DbType = DbType.String
            iPar.Value = password
            comando.Parameters.Add(iPar)

            Try
                conex.Open()
                resultadoValidacion = comando.ExecuteScalar
                conex.Close()

            Catch ex As Exception
                Throw New EL.SIS.EXCEPCIONES.DALExcepcion(ex.Message)
            End Try
            Return resultadoValidacion
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function obtenerTablaUsuario() As List(Of BE.SIS.ENTIDAD.Usuario)
            Dim listadoUsuarios As New List(Of BE.SIS.ENTIDAD.Usuario)

            Dim conexString As String = System.Configuration.ConfigurationManager.ConnectionStrings("MotoPoint").ConnectionString
            Dim sqlQuery As String = "SELECT * FROM tbl_Usuario"

            Dim conex As New SqlConnection
            conex.ConnectionString = conexString

            Dim comando As SqlCommand = conex.CreateCommand
            comando.CommandType = CommandType.Text
            comando.CommandText = sqlQuery

            Dim adapter As New SqlDataAdapter(comando)
            Dim ds As New DataSet

            Try
                adapter.Fill(ds, "Usuario")
                Dim enu As IEnumerator(Of DataRow) = ds.Tables("Usuario").Rows.GetEnumerator

                While enu.MoveNext
                    Dim oUsuario As New BE.SIS.ENTIDAD.Usuario
                    oUsuario.idUsuario = CType(enu.Current("idUsuario"), Integer)
                    oUsuario.usuario = enu.Current("usuario")
                    oUsuario.password = enu.Current("password")
                    oUsuario.legajo = enu.Current("legajo")
                    oUsuario.idioma = enu.Current("idioma")
                    oUsuario.digitoVerificador = enu.Current("digitoVerificador")

                    listadoUsuarios.Add(oUsuario)
                End While
            Catch ex As Exception
                Throw New EL.SIS.EXCEPCIONES.DALExcepcion("Error en BD", ex)
            End Try
            Return listadoUsuarios
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="usuario"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function validarExistenciaUsuario(ByVal usuario As String) As Boolean
            Dim resultadoValidacion As Integer = 0

            Dim conexString As String = System.Configuration.ConfigurationManager.ConnectionStrings("MotoPoint").ConnectionString
            Dim sqlQuery As String = "SELECT [idUsuario] FROM tbl_Usuario WHERE usuario=@usuario"

            Dim conex As New SqlConnection
            conex.ConnectionString = conexString

            Dim comando As SqlCommand = conex.CreateCommand
            comando.CommandType = CommandType.Text
            comando.CommandText = sqlQuery

            Dim iPar As IDataParameter = comando.CreateParameter

            iPar.ParameterName = "usuario"
            iPar.DbType = DbType.String
            iPar.Value = usuario
            comando.Parameters.Add(iPar)

            Try
                conex.Open()
                resultadoValidacion = comando.ExecuteScalar
                conex.Close()

            Catch ex As SqlException
                Throw New EL.SIS.EXCEPCIONES.DALExcepcion("Error en la Base de Datos")
            End Try

            Dim resultado As Boolean
            If Not resultadoValidacion = 0 Then
                resultado = False
            Else
                resultado = True
            End If
            Return resultado
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="listaUsuarios"></param>
        ''' <remarks></remarks>
        Public Sub insertarUsuario(ByVal listaUsuarios As List(Of BE.SIS.ENTIDAD.Usuario))
            Dim conexString As String = System.Configuration.ConfigurationManager.ConnectionStrings("MotoPoint").ConnectionString
            Dim sqlQuery As String = "SELECT * FROM tbl_Usuario"

            Dim adaptador As New SqlDataAdapter(sqlQuery, conexString)
            Dim ds As New DataSet
            Dim cb As New SqlCommandBuilder(adaptador)
            adaptador.UpdateCommand = cb.GetUpdateCommand
            adaptador.InsertCommand = cb.GetInsertCommand
            adaptador.DeleteCommand = cb.GetDeleteCommand

            Try
                adaptador.Fill(ds, "Usuario")

                If ds.Tables("Usuario").Rows.Count = 0 Then
                    Dim ColumnaVerificadora As BE.SIS.ENTIDAD.Usuario = listaUsuarios.Item(0)
                    Dim dr As DataRow = ds.Tables("Usuario").Rows.Add
                    dr("idUsuario") = ColumnaVerificadora.idUsuario.ToString
                    dr("usuario") = ColumnaVerificadora.usuario.ToString
                    dr("password") = ColumnaVerificadora.password.ToString
                    dr("legajo") = ColumnaVerificadora.legajo.ToString
                    dr("idioma") = ColumnaVerificadora.idioma.ToString
                    dr("digitoVerificador") = ColumnaVerificadora.digitoVerificador.ToString
                Else
                    'sobre escribir el regustro cuyo idUsuario=1 (digitos Verificadores verticales)

                    Dim enu As IEnumerator(Of DataRow) = ds.Tables("Usuario").Rows.GetEnumerator
                    While enu.MoveNext
                        If enu.Current.Item(0) = 1 Then
                            enu.Current.Item(1) = listaUsuarios.Item(0).usuario
                            enu.Current.Item(2) = listaUsuarios.Item(0).password
                            enu.Current.Item(3) = listaUsuarios.Item(0).legajo
                            enu.Current.Item(4) = listaUsuarios.Item(0).idioma
                            enu.Current.Item(5) = listaUsuarios.Item(0).digitoVerificador
                        End If

                    End While
                End If

                Dim posicionUltimo As Integer = listaUsuarios.Count
                posicionUltimo = posicionUltimo - 1
                Dim oUsuario2 As BE.SIS.ENTIDAD.Usuario = listaUsuarios.Item(posicionUltimo)
                Dim dr2 As DataRow = ds.Tables("Usuario").NewRow
                dr2("idUsuario") = CType(oUsuario2.idUsuario, Integer)
                dr2("usuario") = oUsuario2.usuario.ToString
                dr2("password") = oUsuario2.password.ToString
                dr2("legajo") = oUsuario2.legajo.ToString
                dr2("idioma") = oUsuario2.idioma.ToString
                dr2("digitoVerificador") = oUsuario2.digitoVerificador.ToString
                ds.Tables("Usuario").Rows.Add(dr2)

                adaptador.Update(ds, "Usuario")
            Catch ex As Exception
                Throw New EL.SIS.EXCEPCIONES.DALExcepcion(ex.Message)
            End Try
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="listadoUsuarios"></param>
        ''' <remarks></remarks>
        Public Sub insertarUsuarioDesdeBackup(ByVal listadoUsuarios As List(Of BE.SIS.ENTIDAD.Usuario))
            Dim conexString As String = System.Configuration.ConfigurationManager.ConnectionStrings("MotoPoint").ConnectionString
            Dim sqlQuery As String = "SELECT * FROM tbl_Usuario"

            Dim adaptador As New SqlDataAdapter(sqlQuery, conexString)
            Dim ds As New DataSet
            Dim cb As New SqlCommandBuilder(adaptador)
            adaptador.UpdateCommand = cb.GetUpdateCommand
            adaptador.InsertCommand = cb.GetInsertCommand
            adaptador.DeleteCommand = cb.GetDeleteCommand

            Dim conex As New SqlConnection
            conex.ConnectionString = conexString

            Dim comando As SqlCommand = conex.CreateCommand
            comando.CommandType = CommandType.Text
            comando.CommandText = "DELETE FROM [MotoPoint].[dbo].[tbl_Usuario]"
            Try
                conex.Open()
                comando.ExecuteScalar()
                conex.Close()
            Catch ex As Exception
                Throw New EL.SIS.EXCEPCIONES.DALExcepcion(ex.Message)
            End Try

            Try
                adaptador.Fill(ds, "Usuario")

                Dim enu As IEnumerator(Of BE.SIS.ENTIDAD.Usuario) = listadoUsuarios.GetEnumerator

                While enu.MoveNext
                    Dim dr As DataRow = ds.Tables("Usuario").NewRow
                    dr("idUsuario") = CType(enu.Current.idUsuario, Integer)
                    dr("usuario") = enu.Current.usuario.ToString
                    dr("password") = enu.Current.password.ToString
                    dr("legajo") = enu.Current.legajo.ToString
                    dr("idioma") = enu.Current.idioma.ToString
                    dr("digitoVerificador") = enu.Current.digitoVerificador.ToString
                    ds.Tables("Usuario").Rows.Add(dr)
                End While
                adaptador.Update(ds, "Usuario")
            Catch ex As Exception
                Throw New EL.SIS.EXCEPCIONES.DALExcepcion(ex.Message)
            End Try
        End Sub
    End Class
End Namespace

