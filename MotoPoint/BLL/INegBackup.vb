Imports BE

Namespace SIS.BUSINESS
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Interface INegBackup
        ' ### EXPORTAR ###
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <remarks></remarks>
        Sub exportarAArchivoUsuario(ByVal ruta As String, ByVal delim As String)
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <remarks></remarks>
        Sub exportarAArchivoBitacora(ByVal ruta As String, ByVal delim As String)
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <remarks></remarks>
        Sub exportarAArchivoUsuarioGrupo(ByVal ruta As String, ByVal delim As String)
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <remarks></remarks>
        Sub exportarAArchivoGrupo(ByVal ruta As String, ByVal delim As String)
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <remarks></remarks>
        Sub exportarAArchivoGrupoPermisos(ByVal ruta As String, ByVal delim As String)
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <remarks></remarks>
        Sub exportarAArchivoMultiIdioma(ByVal ruta As String, ByVal delim As String)
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <remarks></remarks>
        Sub exportarAArchivoPermisos(ByVal ruta As String, ByVal delim As String)
        ' ### IMPORTAR ###
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <remarks></remarks>
        Sub importarDesdeArchivoUsuario(ByVal ruta As String, ByVal delim As String)
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <remarks></remarks>
        Sub importarDesdeArchivoBitacora(ByVal ruta As String, ByVal delim As String)
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <remarks></remarks>
        Sub importarDesdeArchivoGrupo(ByVal ruta As String, ByVal delim As String)
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <remarks></remarks>
        Sub importarDesdeArchivoGrupoPermiso(ByVal ruta As String, ByVal delim As String)
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <remarks></remarks>
        Sub importarDesdeArchivoPermiso(ByVal ruta As String, ByVal delim As String)
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <remarks></remarks>
        Sub importarDesdeArchivoMultiIdioma(ByVal ruta As String, ByVal delim As String)
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <remarks></remarks>
        Sub importarDesdeArchivoUsuarioGrupo(ByVal ruta As String, ByVal delim As String)
        ' ##### INSERT EN BD #####
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="listaUsuarios"></param>
        ''' <remarks></remarks>
        Sub insertarUsuarioDesdeBackup(ByVal listaUsuarios As List(Of BE.SIS.ENTIDAD.Usuario))
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="listaEventos"></param>
        ''' <remarks></remarks>
        Sub insertarBitacoraDesdeBackup(ByVal listaEventos As List(Of BE.SIS.ENTIDAD.Bitacora))
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="listaGrupo"></param>
        ''' <remarks></remarks>
        Sub insertarGrupoDesdeBackup(ByVal listaGrupo As List(Of BE.SIS.ENTIDAD.Grupo))
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="listaGrupoPermiso"></param>
        ''' <remarks></remarks>
        Sub insertarGrupoPermisoDesdeBackup(ByVal listaGrupoPermiso As List(Of BE.SIS.ENTIDAD.GrupoPermiso))
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="listaPermiso"></param>
        ''' <remarks></remarks>
        Sub insertarPermisoDesdeBackup(ByVal listaPermiso As List(Of BE.SIS.ENTIDAD.Permiso))
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="listaMultiIdioma"></param>
        ''' <remarks></remarks>
        Sub insertarMultiIdiomaDesdeBackup(ByVal listaMultiIdioma As List(Of BE.SIS.ENTIDAD.MultiIdioma))
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="listaUsuarioGrupo"></param>
        ''' <remarks></remarks>
        Sub insertarUsuarioGrupoDesdeBackup(ByVal listaUsuarioGrupo As List(Of BE.SIS.ENTIDAD.UsuarioGrupo))
    End Interface
End Namespace