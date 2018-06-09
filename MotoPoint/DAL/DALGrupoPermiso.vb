Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data.Common
Imports EL

Namespace SIS.DATOS
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class DALGrupoPermiso
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="idGrupo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function obtenerPermisosPorIdGrupo(ByVal idGrupo As Integer) As List(Of BE.SIS.ENTIDAD.GrupoPermiso)
            Dim listadoGrupoPermiso As New List(Of BE.SIS.ENTIDAD.GrupoPermiso)

            Dim conexString As String = System.Configuration.ConfigurationManager.ConnectionStrings("MotoPoint").ConnectionString
            Dim sqlQuery As String = "SELECT * FROM tbl_GrupoPermisos WHERE idGrupo=@idGrupo"

            Dim conex As New SqlConnection
            conex.ConnectionString = conexString

            Dim comando As SqlCommand = conex.CreateCommand
            comando.CommandType = CommandType.Text
            comando.CommandText = sqlQuery

            Dim iPar As IDataParameter = comando.CreateParameter
            iPar.ParameterName = "idGrupo"
            iPar.DbType = DbType.Int32
            iPar.Value = idGrupo
            comando.Parameters.Add(iPar)

            Dim adapter As New SqlDataAdapter(comando)
            Dim ds As New DataSet

            Try
                adapter.Fill(ds, "GrupoPermiso")
                Dim enu As IEnumerator(Of DataRow) = ds.Tables("GrupoPermiso").Rows.GetEnumerator
                While enu.MoveNext
                    Dim oGrupoPermiso As New BE.SIS.ENTIDAD.GrupoPermiso
                    oGrupoPermiso.idGrupo = CType(enu.Current("idGrupo"), Integer)
                    oGrupoPermiso.idPermiso = CType(enu.Current("idPermisos"), Integer)
                    listadoGrupoPermiso.Add(oGrupoPermiso)
                End While
            Catch
            End Try
            Return listadoGrupoPermiso
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function obtenerGrupoPermiso() As List(Of BE.SIS.ENTIDAD.GrupoPermiso)
            Dim listadoGrupoPermiso As New List(Of BE.SIS.ENTIDAD.GrupoPermiso)

            Dim conexString As String = System.Configuration.ConfigurationManager.ConnectionStrings("MotoPoint").ConnectionString
            Dim sqlQuery As String = "SELECT * FROM tbl_GrupoPermisos"

            Dim conex As New SqlConnection
            conex.ConnectionString = conexString

            Dim comando As SqlCommand = conex.CreateCommand
            comando.CommandType = CommandType.Text
            comando.CommandText = sqlQuery

            Dim adapter As New SqlDataAdapter(comando)
            Dim ds As New DataSet

            Try
                adapter.Fill(ds, "GrupoPermiso")
                Dim enu As IEnumerator(Of DataRow) = ds.Tables("GrupoPermiso").Rows.GetEnumerator
                While enu.MoveNext
                    Dim oGrupoPermiso As New BE.SIS.ENTIDAD.GrupoPermiso
                    oGrupoPermiso.idGrupo = CType(enu.Current("idGrupo"), Integer)
                    oGrupoPermiso.idPermiso = enu.Current("idPermisos")
                    listadoGrupoPermiso.Add(oGrupoPermiso)
                End While
            Catch
            End Try
            Return listadoGrupoPermiso
        End Function
    End Class
End Namespace