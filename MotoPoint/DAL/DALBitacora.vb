Imports System.Data.SqlClient
Imports System.Data
Imports System.Exception
Imports EL
Imports BE

Namespace SIS.DATOS
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class DALBitacora
        Public Function obtenerUltimoId() As Integer
            Dim ultimoId As Integer

            Dim conexString As String = System.Configuration.ConfigurationManager.ConnectionStrings("MotoPoint").ConnectionString
            Dim sqlQuery As String = "SELECT MAX(idEvento) FROM tbl_Bitacora"

            Dim conex As New SqlConnection
            conex.ConnectionString = conexString

            Dim comando As SqlCommand = conex.CreateCommand
            comando.CommandType = CommandType.Text
            comando.CommandText = sqlQuery

            Try
                conex.Open()
                ultimoId = comando.ExecuteScalar
                conex.Close()

            Catch ex As SqlException
                Throw New EL.SIS.EXCEPCIONES.DALExcepcion(ex.Message)
            End Try
            Return ultimoId
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="oBitacora"></param>
        ''' <remarks></remarks>
        Public Sub registrarEnBitacoraBD(ByVal oBitacora As BE.SIS.ENTIDAD.Bitacora)

            Dim conexString As String = System.Configuration.ConfigurationManager.ConnectionStrings("MotoPoint").ConnectionString
            Dim sqlQuery As String = "SELECT * FROM tbl_Bitacora"

            Dim adaptador As New SqlDataAdapter(sqlQuery, conexString)
            Dim ds As New DataSet
            Dim cb As New SqlCommandBuilder(adaptador)
            adaptador.UpdateCommand = cb.GetUpdateCommand
            adaptador.InsertCommand = cb.GetInsertCommand
            adaptador.DeleteCommand = cb.GetDeleteCommand

            Try
                adaptador.Fill(ds, "Bitacora")

                Dim dr As DataRow = ds.Tables("Bitacora").NewRow
                dr("idEvento") = oBitacora.idEvento
                dr("idUsuario") = oBitacora.idUsuario
                dr("descripcion") = oBitacora.descripcion
                dr("fecha") = oBitacora.fecha
                ds.Tables("Bitacora").Rows.Add(dr)

                adaptador.Update(ds, "Bitacora")
            Catch ex As SqlException
                Throw New EL.SIS.EXCEPCIONES.DALExcepcion(ex.Message)
            End Try
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function obtenerEventos() As List(Of BE.SIS.ENTIDAD.Bitacora)
            Dim listado As New List(Of BE.SIS.ENTIDAD.Bitacora)

            Dim conexString As String = System.Configuration.ConfigurationManager.ConnectionStrings("MotoPoint").ConnectionString
            Dim sqlQuery As String = "SELECT * FROM tbl_Bitacora"

            Dim adaptador As New SqlDataAdapter(sqlQuery, conexString)
            Dim ds As New DataSet
            Dim cb As New SqlCommandBuilder(adaptador)
            adaptador.UpdateCommand = cb.GetUpdateCommand
            adaptador.InsertCommand = cb.GetInsertCommand
            adaptador.DeleteCommand = cb.GetDeleteCommand

            Try
                adaptador.Fill(ds, "Bitacora")

                Dim enu As IEnumerator(Of DataRow) = ds.Tables("Bitacora").Rows.GetEnumerator
                While enu.MoveNext
                    Dim oBitacora As New BE.SIS.ENTIDAD.Bitacora
                    oBitacora.idEvento = CType(enu.Current.Item(0), Integer)
                    oBitacora.idUsuario = CType(enu.Current.Item(1), Integer)
                    oBitacora.descripcion = enu.Current.Item(2).ToString
                    oBitacora.fecha = CType(enu.Current.Item(3), Date)
                    listado.Add(oBitacora)
                End While

            Catch ex As SqlException
                Throw New EL.SIS.EXCEPCIONES.DALExcepcion(ex.Message)
            End Try

            Return listado
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="listaEventos"></param>
        ''' <remarks></remarks>
        Public Sub insertarBitacoraDesdeBackup(ByVal listaEventos As List(Of BE.SIS.ENTIDAD.Bitacora))

            Dim conexString As String = System.Configuration.ConfigurationManager.ConnectionStrings("MotoPoint").ConnectionString
            Dim sqlQuery As String = "SELECT * FROM tbl_Bitacora"

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
            comando.CommandText = "DELETE FROM [MotoPoint].[dbo].[tbl_Bitacora]"
            Try
                conex.Open()
                comando.ExecuteScalar()
                conex.Close()
            Catch ex As Exception
                Throw New EL.SIS.EXCEPCIONES.DALExcepcion(ex.Message)
            End Try

            Try
                adaptador.Fill(ds, "Bitacora")

                Dim enu As IEnumerator(Of BE.SIS.ENTIDAD.Bitacora) = listaEventos.GetEnumerator

                While enu.MoveNext
                    Dim dr As DataRow = ds.Tables("Bitacora").NewRow
                    dr("idEvento") = CType(enu.Current.idEvento, Integer)
                    dr("idUsuario") = CType(enu.Current.idUsuario, Integer)
                    dr("descripcion") = enu.Current.descripcion
                    dr("fecha") = CType(enu.Current.fecha, Date)
                    ds.Tables("Bitacora").Rows.Add(dr)
                End While
                adaptador.Update(ds, "Bitacora")
            Catch ex As SqlException
                Throw New EL.SIS.EXCEPCIONES.DALExcepcion(ex.Message)
            End Try
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="listaGrupo"></param>
        ''' <remarks></remarks>
        Public Sub insertarGrupoDesdeBackup(ByVal listaGrupo As List(Of BE.SIS.ENTIDAD.Grupo))

            Dim conexString As String = System.Configuration.ConfigurationManager.ConnectionStrings("MotoPoint").ConnectionString
            Dim sqlQuery As String = "SELECT * FROM tbl_Grupo"

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
            comando.CommandText = "DELETE FROM [MotoPoint].[dbo].[tbl_Grupo]"
            Try
                conex.Open()
                comando.ExecuteScalar()
                conex.Close()
            Catch ex As Exception
                Throw New EL.SIS.EXCEPCIONES.DALExcepcion(ex.Message)
            End Try

            Try
                adaptador.Fill(ds, "Grupo")

                Dim enu As IEnumerator(Of BE.SIS.ENTIDAD.Grupo) = listaGrupo.GetEnumerator

                While enu.MoveNext
                    Dim dr As DataRow = ds.Tables("Grupo").NewRow
                    dr("idGrupo") = CType(enu.Current.idGrupo, Integer)
                    dr("grupo") = enu.Current.grupo
                    dr("descripcion") = enu.Current.descripcion
                    ds.Tables("Grupo").Rows.Add(dr)
                End While
                adaptador.Update(ds, "Grupo")
            Catch ex As SqlException
                Throw New EL.SIS.EXCEPCIONES.DALExcepcion(ex.Message)
            End Try
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="listaGrupoPermiso"></param>
        ''' <remarks></remarks>
        Public Sub insertarGrupoPermisoDesdeBackup(ByVal listaGrupoPermiso As List(Of BE.SIS.ENTIDAD.GrupoPermiso))

            Dim conexString As String = System.Configuration.ConfigurationManager.ConnectionStrings("MotoPoint").ConnectionString
            Dim sqlQuery As String = "SELECT * FROM tbl_GrupoPermisos"

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
            comando.CommandText = "DELETE FROM [MotoPoint].[dbo].[tbl_GrupoPermisos]"
            Try
                conex.Open()
                comando.ExecuteScalar()
                conex.Close()
            Catch ex As Exception
                Throw New EL.SIS.EXCEPCIONES.DALExcepcion(ex.Message)
            End Try

            Try
                adaptador.Fill(ds, "GrupoPermiso")

                Dim enu As IEnumerator(Of BE.SIS.ENTIDAD.GrupoPermiso) = listaGrupoPermiso.GetEnumerator

                While enu.MoveNext
                    Dim dr As DataRow = ds.Tables("GrupoPermiso").NewRow
                    dr("idGrupo") = CType(enu.Current.idGrupo, Integer)
                    dr("idPermisos") = CType(enu.Current.idPermiso, Integer)
                    ds.Tables("GrupoPermiso").Rows.Add(dr)
                End While
                adaptador.Update(ds, "GrupoPermiso")
            Catch ex As SqlException
                Throw New EL.SIS.EXCEPCIONES.DALExcepcion(ex.Message)
            End Try
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="listaPermiso"></param>
        ''' <remarks></remarks>
        Public Sub insertarPermisoDesdeBackup(ByVal listaPermiso As List(Of BE.SIS.ENTIDAD.Permiso))

            Dim conexString As String = System.Configuration.ConfigurationManager.ConnectionStrings("MotoPoint").ConnectionString
            Dim sqlQuery As String = "SELECT * FROM tbl_Permisos"

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
            comando.CommandText = "DELETE FROM [MotoPoint].[dbo].[tbl_Permisos]"
            Try
                conex.Open()
                comando.ExecuteScalar()
                conex.Close()
            Catch ex As Exception
                Throw New EL.SIS.EXCEPCIONES.DALExcepcion(ex.Message)
            End Try

            Try
                adaptador.Fill(ds, "Permiso")

                Dim enu As IEnumerator(Of BE.SIS.ENTIDAD.Permiso) = listaPermiso.GetEnumerator

                While enu.MoveNext
                    Dim dr As DataRow = ds.Tables("Permiso").NewRow
                    dr("idPermiso") = CType(enu.Current.idPermiso, Integer)
                    dr("descripcion") = enu.Current.descripcion
                    ds.Tables("Permiso").Rows.Add(dr)
                End While
                adaptador.Update(ds, "Permiso")
            Catch ex As SqlException
                Throw New EL.SIS.EXCEPCIONES.DALExcepcion(ex.Message)
            End Try
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="listaMultiIdioma"></param>
        ''' <remarks></remarks>
        Public Sub insertarMultiIdiomaDesdeBackup(ByVal listaMultiIdioma As List(Of BE.SIS.ENTIDAD.MultiIdioma))

            Dim conexString As String = System.Configuration.ConfigurationManager.ConnectionStrings("MotoPoint").ConnectionString
            Dim sqlQuery As String = "SELECT * FROM tbl_MultiIdioma"

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
            comando.CommandText = "DELETE FROM [MotoPoint].[dbo].[tbl_MultiIdioma]"
            Try
                conex.Open()
                comando.ExecuteScalar()
                conex.Close()
            Catch ex As Exception
                Throw New EL.SIS.EXCEPCIONES.DALExcepcion(ex.Message)
            End Try

            Try
                adaptador.Fill(ds, "MultiIdioma")

                Dim enu As IEnumerator(Of BE.SIS.ENTIDAD.MultiIdioma) = listaMultiIdioma.GetEnumerator

                While enu.MoveNext
                    Dim dr As DataRow = ds.Tables("MultiIdioma").NewRow
                    dr("componente") = enu.Current.componente
                    dr("ikey") = enu.Current.iKey
                    dr("value") = enu.Current.value
                    ds.Tables("MultiIdioma").Rows.Add(dr)
                End While
                adaptador.Update(ds, "MultiIdioma")
            Catch ex As SqlException
                Throw New EL.SIS.EXCEPCIONES.DALExcepcion(ex.Message)
            End Try
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="listaUsuarioGrupo"></param>
        ''' <remarks></remarks>
        Public Sub insertarUsuarioGrupoDesdeBackup(ByVal listaUsuarioGrupo As List(Of BE.SIS.ENTIDAD.UsuarioGrupo))

            Dim conexString As String = System.Configuration.ConfigurationManager.ConnectionStrings("MotoPoint").ConnectionString
            Dim sqlQuery As String = "SELECT * FROM tbl_UsuarioGrupo"

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
            comando.CommandText = "DELETE FROM [MotoPoint].[dbo].[tbl_UsuarioGrupo]"
            Try
                conex.Open()
                comando.ExecuteScalar()
                conex.Close()
            Catch ex As Exception
                Throw New EL.SIS.EXCEPCIONES.DALExcepcion(ex.Message)
            End Try

            Try
                adaptador.Fill(ds, "UsuarioGrupo")

                Dim enu As IEnumerator(Of BE.SIS.ENTIDAD.UsuarioGrupo) = listaUsuarioGrupo.GetEnumerator

                While enu.MoveNext
                    Dim dr As DataRow = ds.Tables("UsuarioGrupo").NewRow
                    dr("idUsuario") = CType(enu.Current.idUsuario, Integer)
                    dr("idGrupo") = CType(enu.Current.idGrupo, Integer)
                    ds.Tables("UsuarioGrupo").Rows.Add(dr)
                End While
                adaptador.Update(ds, "UsuarioGrupo")
            Catch ex As SqlException
                Throw New EL.SIS.EXCEPCIONES.DALExcepcion(ex.Message)
            End Try
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="listaUsuarios"></param>
        ''' <remarks></remarks>
        Public Sub insertarUsuarioDesdeBackup(ByVal listaUsuarios As List(Of BE.SIS.ENTIDAD.Usuario))

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

                Dim enu As IEnumerator(Of BE.SIS.ENTIDAD.Usuario) = listaUsuarios.GetEnumerator

                While enu.MoveNext
                    Dim dr As DataRow = ds.Tables("Usuario").NewRow
                    dr("idUsuario") = CType(enu.Current.idUsuario, Integer)
                    dr("usuario") = enu.Current.usuario
                    dr("password") = enu.Current.password
                    dr("legajo") = enu.Current.legajo
                    dr("idioma") = enu.Current.idioma
                    dr("digitoVerificador") = enu.Current.digitoVerificador
                    ds.Tables("Usuario").Rows.Add(dr)
                End While
                adaptador.Update(ds, "Usuario")
            Catch ex As SqlException
                Throw New EL.SIS.EXCEPCIONES.DALExcepcion(ex.Message)
            End Try
        End Sub
    End Class
End Namespace
