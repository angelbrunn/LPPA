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
    Public Class DALUsuarioGrupo
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="idUsuario"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function obtenerGrupoPorIdUsuario(ByVal idUsuario As Integer) As List(Of BE.SIS.ENTIDAD.UsuarioGrupo)
            Dim listadoUsuarioGrupo As New List(Of BE.SIS.ENTIDAD.UsuarioGrupo)

            Dim conexString As String = System.Configuration.ConfigurationManager.ConnectionStrings("MotoPoint").ConnectionString
            Dim sqlQuery As String = "SELECT * FROM tbl_UsuarioGrupo WHERE idUsuario=@idUsuario"

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
                adapter.Fill(ds, "UsuarioGrupo")
                Dim enu As IEnumerator(Of DataRow) = ds.Tables("UsuarioGrupo").Rows.GetEnumerator
                While enu.MoveNext
                    Dim oUsuarioGrupo As New BE.SIS.ENTIDAD.UsuarioGrupo
                    oUsuarioGrupo.idUsuario = CType(enu.Current("idUsuario"), Integer)
                    oUsuarioGrupo.idGrupo = CType(enu.Current("idGrupo"), Integer)
                    listadoUsuarioGrupo.Add(oUsuarioGrupo)
                End While
            Catch
            End Try
            Return listadoUsuarioGrupo
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="oUsuarioGrupo"></param>
        ''' <remarks></remarks>
        Public Sub insertarUsuarioGrupo(ByVal oUsuarioGrupo As BE.SIS.ENTIDAD.UsuarioGrupo)
            Dim conexString As String = System.Configuration.ConfigurationManager.ConnectionStrings("MotoPoint").ConnectionString
            Dim sqlQuery As String = "INSERT INTO tbl_UsuarioGrupo([idUsuario],[idGrupo]) VALUES (@idUsuario,@idGrupo)"

            Dim conex As New SqlConnection
            conex.ConnectionString = conexString

            Dim comando As SqlCommand = conex.CreateCommand
            comando.CommandType = CommandType.Text
            comando.CommandText = sqlQuery

            Dim iPar As IDataParameter = comando.CreateParameter

            iPar.ParameterName = "idUsuario"
            iPar.DbType = DbType.Int32
            iPar.Value = oUsuarioGrupo.idUsuario
            comando.Parameters.Add(iPar)

            iPar = comando.CreateParameter
            iPar.ParameterName = "idGrupo"
            iPar.DbType = DbType.Int32
            iPar.Value = oUsuarioGrupo.idGrupo
            comando.Parameters.Add(iPar)

            Try
                conex.Open()
                comando.ExecuteNonQuery()
                conex.Close()
            Catch ex As Exception
            End Try
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function obtenerTablaUsuarioGrupo() As List(Of BE.SIS.ENTIDAD.UsuarioGrupo)
            Dim listaUsuarioGrupo As New List(Of BE.SIS.ENTIDAD.UsuarioGrupo)

            Dim conexString As String = System.Configuration.ConfigurationManager.ConnectionStrings("MotoPoint").ConnectionString
            Dim sqlQuery As String = "SELECT * FROM tbl_UsuarioGrupo"

            Dim conex As New SqlConnection
            conex.ConnectionString = conexString

            Dim comando As SqlCommand = conex.CreateCommand
            comando.CommandType = CommandType.Text
            comando.CommandText = sqlQuery

            Dim adapter As New SqlDataAdapter(comando)
            Dim ds As New DataSet

            Try
                adapter.Fill(ds, "UsuarioGrupo")
                Dim enu As IEnumerator(Of DataRow) = ds.Tables("UsuarioGrupo").Rows.GetEnumerator

                While enu.MoveNext
                    Dim oUsuarioGrupo As New BE.SIS.ENTIDAD.UsuarioGrupo
                    oUsuarioGrupo.idUsuario = CType(enu.Current("idUsuario"), Integer)
                    oUsuarioGrupo.idGrupo = CType(enu.Current("idGrupo"), Integer)
                    listaUsuarioGrupo.Add(oUsuarioGrupo)
                End While
            Catch ex As Exception
                Throw New EL.SIS.EXCEPCIONES.DALExcepcion("Error en BD", ex)
            End Try
            Return listaUsuarioGrupo
        End Function
    End Class
End Namespace