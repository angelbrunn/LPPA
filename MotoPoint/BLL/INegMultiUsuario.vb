Imports BE

Namespace SIS.BUSINESS
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Interface INegMultiUsuario
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="oUsuario"></param>
        ''' <remarks></remarks>
        Sub insertarUsuario(ByVal oUsuario As BE.SIS.ENTIDAD.Usuario)
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function obtenerIdParaUsuario() As Integer
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="idUsuario"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function obtenerUsuario(ByVal idUsuario As Integer) As BE.SIS.ENTIDAD.Usuario
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="legajo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function obtenerUsuarioPorLegajo(ByVal legajo As Integer) As BE.SIS.ENTIDAD.Usuario
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="usuario"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function validarExistenciaUsuario(ByVal usuario As String) As Boolean
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="idGrupo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function obtenerGrupoPorId(ByVal idGrupo As Integer) As BE.SIS.ENTIDAD.Grupo
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function obtenerGrupos() As List(Of BE.SIS.ENTIDAD.Grupo)
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="nombreGrupo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function obtenerDescripcionGrupoPorNombre(ByVal nombreGrupo As String) As String
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="nombreGrupo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function obtenerGrupoPorNombre(ByVal nombreGrupo As String) As BE.SIS.ENTIDAD.Grupo
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="idPermiso"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function obtenerPermisoPorId(ByVal idPermiso As Integer) As BE.SIS.ENTIDAD.Permiso
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="usuario"></param>
        ''' <param name="password"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function login(ByVal usuario As String, ByVal password As String) As Integer
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function verificarConsistenciaBD() As Boolean
    End Interface
End Namespace
