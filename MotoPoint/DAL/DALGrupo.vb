Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data.Common
Imports EL


Namespace SIS.DATOS
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class DALGrupo
        ''' <summary>
        ''' ###ADO DESCONECTADO###
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function obtenerGrupos() As List(Of BE.SIS.ENTIDAD.Grupo)
            Dim listadoGrupos As New List(Of BE.SIS.ENTIDAD.Grupo)

            Dim conexString As String = System.Configuration.ConfigurationManager.ConnectionStrings("MotoPoint").ConnectionString
            Dim sqlQuery As String = "SELECT * FROM tbl_Grupo"

            Dim conex As New SqlConnection
            conex.ConnectionString = conexString

            Dim comando As SqlCommand = conex.CreateCommand
            comando.CommandType = CommandType.Text
            comando.CommandText = sqlQuery

            Dim adapter As New SqlDataAdapter(comando)
            Dim ds As New DataSet

            Try
                adapter.Fill(ds, "Grupo")
                Dim enu As IEnumerator(Of DataRow) = ds.Tables("Grupo").Rows.GetEnumerator
                While enu.MoveNext
                    Dim oGrupo As New BE.SIS.ENTIDAD.Grupo
                    oGrupo.idGrupo = CType(enu.Current("idGrupo"), Integer)
                    oGrupo.grupo = enu.Current("grupo")
                    oGrupo.descripcion = enu.Current("descripcion")
                    listadoGrupos.Add(oGrupo)
                End While
            Catch

            End Try
            Return listadoGrupos
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="idGrupo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function obtenerGrupoPorId(ByVal idGrupo As Integer) As BE.SIS.ENTIDAD.Grupo
            Dim oGrupo As New BE.SIS.ENTIDAD.Grupo

            Dim conexString As String = System.Configuration.ConfigurationManager.ConnectionStrings("MotoPoint").ConnectionString
            Dim sqlQuery As String = "SELECT * FROM tbl_Grupo WHERE idGrupo=@idGrupo"

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
                adapter.Fill(ds, "Grupo")
                Dim dr As DataRow = ds.Tables("Grupo").Rows.Item(0)
                oGrupo.idGrupo = CType(dr("idGrupo"), Integer)
                oGrupo.grupo = dr("grupo")
                oGrupo.descripcion = dr("descripcion")

            Catch
            End Try
            Return oGrupo
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="nombreGrupo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function obtenerDescripcionGrupoPorNombreGrupo(ByVal nombreGrupo As String) As String
            Dim descripcionGrupo As String = "Error"

            Dim conexString As String = System.Configuration.ConfigurationManager.ConnectionStrings("MotoPoint").ConnectionString
            Dim sqlQuery As String = "SELECT * FROM tbl_Grupo WHERE grupo=@nombreGrupo"

            Dim conex As New SqlConnection
            conex.ConnectionString = conexString

            Dim comando As SqlCommand = conex.CreateCommand
            comando.CommandType = CommandType.Text
            comando.CommandText = sqlQuery

            Dim iPar As IDataParameter = comando.CreateParameter
            iPar.ParameterName = "nombreGrupo"
            iPar.DbType = DbType.String
            iPar.Value = nombreGrupo
            comando.Parameters.Add(iPar)

            Dim adapter As New SqlDataAdapter(comando)
            Dim ds As New DataSet

            Try
                adapter.Fill(ds, "Grupo")
                Dim dr As DataRow = ds.Tables("Grupo").Rows.Item(0)
                descripcionGrupo = dr("descripcion")
            Catch
            End Try
            Return descripcionGrupo
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="nombreGrupo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function obtenerGrupoPorNombreGrupo(ByVal nombreGrupo As String) As BE.SIS.ENTIDAD.Grupo

            Dim conexString As String = System.Configuration.ConfigurationManager.ConnectionStrings("MotoPoint").ConnectionString
            Dim sqlQuery As String = "SELECT * FROM tbl_Grupo WHERE grupo=@nombreGrupo"

            Dim conex As New SqlConnection
            conex.ConnectionString = conexString

            Dim comando As SqlCommand = conex.CreateCommand
            comando.CommandType = CommandType.Text
            comando.CommandText = sqlQuery

            Dim iPar As IDataParameter = comando.CreateParameter
            iPar.ParameterName = "nombreGrupo"
            iPar.DbType = DbType.String
            iPar.Value = nombreGrupo
            comando.Parameters.Add(iPar)

            Dim adapter As New SqlDataAdapter(comando)
            Dim ds As New DataSet

            Dim oGrupo As New BE.SIS.ENTIDAD.Grupo

            Try
                adapter.Fill(ds, "Grupo")
                Dim dr As DataRow = ds.Tables("Grupo").Rows.Item(0)

                oGrupo.idGrupo = dr("idGrupo")
                oGrupo.grupo = dr("grupo")
                oGrupo.descripcion = dr("descripcion")

            Catch
            End Try
            Return oGrupo
        End Function
    End Class
End Namespace
