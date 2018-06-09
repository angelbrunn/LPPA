Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data.Common
Imports EL


Namespace SIS.DATOS
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class DALPermiso
        ''' <summary>
        ''' ###ADO DESCONECTADO###
        ''' </summary>
        ''' <param name="idPermiso"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function obtenerPermisoPorId(ByVal idPermiso As Integer) As BE.SIS.ENTIDAD.Permiso
            Dim oPermiso As New BE.SIS.ENTIDAD.Permiso

            Dim conexString As String = System.Configuration.ConfigurationManager.ConnectionStrings("MotoPoint").ConnectionString
            Dim sqlQuery As String = "SELECT * FROM tbl_Permisos WHERE idPermiso=@idPermiso"

            Dim conex As New SqlConnection
            conex.ConnectionString = conexString

            Dim comando As SqlCommand = conex.CreateCommand
            comando.CommandType = CommandType.Text
            comando.CommandText = sqlQuery

            Dim iPar As IDataParameter = comando.CreateParameter
            iPar.ParameterName = "idPermiso"
            iPar.DbType = DbType.Int32
            iPar.Value = idPermiso
            comando.Parameters.Add(iPar)

            Dim adapter As New SqlDataAdapter(comando)
            Dim ds As New DataSet

            Try
                adapter.Fill(ds, "Permiso")
                Dim dr As DataRow = ds.Tables("Permiso").Rows.Item(0)
                oPermiso.idPermiso = CType(dr("idPermiso"), Integer)
                oPermiso.descripcion = dr("descripcion")
            Catch
            End Try
            Return oPermiso
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function obtenerPermiso() As List(Of BE.SIS.ENTIDAD.Permiso)
            Dim listadoPermiso As New List(Of BE.SIS.ENTIDAD.Permiso)

            Dim conexString As String = System.Configuration.ConfigurationManager.ConnectionStrings("MotoPoint").ConnectionString
            Dim sqlQuery As String = "SELECT * FROM tbl_Permisos"

            Dim conex As New SqlConnection
            conex.ConnectionString = conexString

            Dim comando As SqlCommand = conex.CreateCommand
            comando.CommandType = CommandType.Text
            comando.CommandText = sqlQuery

            Dim adapter As New SqlDataAdapter(comando)
            Dim ds As New DataSet

            Try
                adapter.Fill(ds, "Permiso")
                Dim enu As IEnumerator(Of DataRow) = ds.Tables("Permiso").Rows.GetEnumerator
                While enu.MoveNext
                    Dim oPermiso As New BE.SIS.ENTIDAD.Permiso
                    oPermiso.idPermiso = CType(enu.Current("idPermiso"), Integer)
                    oPermiso.descripcion = enu.Current("descripcion")
                    listadoPermiso.Add(oPermiso)
                End While
            Catch
            End Try
            Return listadoPermiso
        End Function
    End Class
End Namespace
