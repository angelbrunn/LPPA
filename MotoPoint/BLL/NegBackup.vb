Imports System.IO
Imports IO
Imports BE
Imports DAL

Namespace SIS.BUSINESS
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class NegBackup
        Implements INegBackup
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Dim interfazNegMultiUsuario As INegMultiUsuario = New NegMultiUsuario
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <remarks></remarks>
        Sub exportarAArchivoUsuario(ByVal ruta As String, ByVal delim As String) Implements INegBackup.exportarAArchivoUsuario
            Dim oIOBackup As New IO.SIS.ESCRITURA.IOBackup
            Dim listaUsuario As New List(Of BE.SIS.ENTIDAD.Usuario)
            Dim oDalUsuario As New DAL.SIS.DATOS.DALUsuario

            Try
                listaUsuario = oDalUsuario.obtenerTablaUsuario()
                oIOBackup.escribirArchivoUsuario(ruta, delim, listaUsuario)
            Catch ex As Exception
            End Try
        End Sub
        ''' <summary>
        ''' exportarAArchivoBitacora
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <remarks></remarks>
        Sub exportarAArchivoBitacora(ByVal ruta As String, ByVal delim As String) Implements INegBackup.exportarAArchivoBitacora
            Dim oIOBackup As New IO.SIS.ESCRITURA.IOBackup
            Dim listaEventos As New List(Of BE.SIS.ENTIDAD.Bitacora)
            Dim oDalBitacora As New DAL.SIS.DATOS.DALBitacora

            Try
                listaEventos = oDalBitacora.obtenerEventos()
                oIOBackup.escribirArchivoBitacora(ruta, delim, listaEventos)
            Catch ex As Exception
            End Try
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <remarks></remarks>
        Sub exportarAArchivoUsuarioGrupo(ByVal ruta As String, ByVal delim As String) Implements INegBackup.exportarAArchivoUsuarioGrupo
            Dim oIOBackup As New IO.SIS.ESCRITURA.IOBackup
            Dim listaUsuarioGrupo As New List(Of BE.SIS.ENTIDAD.UsuarioGrupo)
            Dim oDalUsuarioGrupo As New DAL.SIS.DATOS.DALUsuarioGrupo

            Try
                listaUsuarioGrupo = oDalUsuarioGrupo.obtenerTablaUsuarioGrupo()
                oIOBackup.escribirArchivoUsuarioGrupo(ruta, delim, listaUsuarioGrupo)
            Catch ex As Exception
            End Try
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <remarks></remarks>
        Sub exportarAArchivoGrupo(ByVal ruta As String, ByVal delim As String) Implements INegBackup.exportarAArchivoGrupo
            Dim oIOBackup As New IO.SIS.ESCRITURA.IOBackup
            Dim listaGrupo As New List(Of BE.SIS.ENTIDAD.Grupo)
            Dim oDalGrupo As New DAL.SIS.DATOS.DALGrupo

            Try
                listaGrupo = oDalGrupo.obtenerGrupos()
                oIOBackup.escribirArchivoGrupo(ruta, delim, listaGrupo)
            Catch ex As IOException
            End Try
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <remarks></remarks>
        Sub exportarAArchivoGrupoPermisos(ByVal ruta As String, ByVal delim As String) Implements INegBackup.exportarAArchivoGrupoPermisos
            Dim oIOBackup As New IO.SIS.ESCRITURA.IOBackup
            Dim listaGrupoPermiso As New List(Of BE.SIS.ENTIDAD.GrupoPermiso)
            Dim oDalGrupoPermiso As New DAL.SIS.DATOS.DALGrupoPermiso

            Try
                listaGrupoPermiso = oDalGrupoPermiso.obtenerGrupoPermiso()
                oIOBackup.escribirArchivoGrupoPermiso(ruta, delim, listaGrupoPermiso)
            Catch ex As IOException
            End Try
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <remarks></remarks>
        Sub exportarAArchivoPermisos(ByVal ruta As String, ByVal delim As String) Implements INegBackup.exportarAArchivoPermisos
            Dim oIOBackup As New IO.SIS.ESCRITURA.IOBackup
            Dim listaPermiso As New List(Of BE.SIS.ENTIDAD.Permiso)
            Dim oDalPermiso As New DAL.SIS.DATOS.DALPermiso

            Try
                listaPermiso = oDalPermiso.obtenerPermiso()
                oIOBackup.escribirArchivoPermiso(ruta, delim, listaPermiso)
            Catch ex As IOException
            End Try
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <remarks></remarks>
        Sub exportarAArchivoMultiIdioma(ByVal ruta As String, ByVal delim As String) Implements INegBackup.exportarAArchivoMultiIdioma
            Dim oIOBackup As New IO.SIS.ESCRITURA.IOBackup
            Dim listaMultiIdioma As New List(Of BE.SIS.ENTIDAD.MultiIdioma)
            Dim oDalMultiIdioma As New DAL.SIS.DATOS.DALMultiIdioma

            Try
                listaMultiIdioma = oDalMultiIdioma.obtenerTablaMultiIdiomaAll()
                oIOBackup.escribirArchivoMultiIdioma(ruta, delim, listaMultiIdioma)
            Catch ex As IOException
            End Try
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <remarks></remarks>
        Sub importarDesdeArchivoUsuario(ByVal ruta As String, ByVal delim As String) Implements INegBackup.importarDesdeArchivoUsuario
            Dim oIOBackup As New IO.SIS.ESCRITURA.IOBackup
            Dim listaUsuario As New List(Of BE.SIS.ENTIDAD.Usuario)

            listaUsuario = oIOBackup.leerArchivoUsuario(ruta, delim)

            Me.insertarUsuarioDesdeBackup(listaUsuario)
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <remarks></remarks>
        Sub importarDesdeArchivoBitacora(ByVal ruta As String, ByVal delim As String) Implements INegBackup.importarDesdeArchivoBitacora
            Dim oIOBackup As New IO.SIS.ESCRITURA.IOBackup
            Dim listaBitacora As New List(Of BE.SIS.ENTIDAD.Bitacora)

            listaBitacora = oIOBackup.leerArchivoBitacora(ruta, delim)

            Me.insertarBitacoraDesdeBackup(listaBitacora)
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <remarks></remarks>
        Sub importarDesdeArchivoGrupo(ByVal ruta As String, ByVal delim As String) Implements INegBackup.importarDesdeArchivoGrupo
            Dim oIOBackup As New IO.SIS.ESCRITURA.IOBackup
            Dim listaGrupo As New List(Of BE.SIS.ENTIDAD.Grupo)

            listaGrupo = oIOBackup.leerArchivoGrupo(ruta, delim)

            Me.insertarGrupoDesdeBackup(listaGrupo)
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <remarks></remarks>
        Sub importarDesdeArchivoGrupoPermiso(ByVal ruta As String, ByVal delim As String) Implements INegBackup.importarDesdeArchivoGrupoPermiso
            Dim oIOBackup As New IO.SIS.ESCRITURA.IOBackup
            Dim listaGrupoPermiso As New List(Of BE.SIS.ENTIDAD.GrupoPermiso)

            listaGrupoPermiso = oIOBackup.leerArchivoGrupoPermiso(ruta, delim)

            Me.insertarGrupoPermisoDesdeBackup(listaGrupoPermiso)
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <remarks></remarks>
        Sub importarDesdeArchivoPermiso(ByVal ruta As String, ByVal delim As String) Implements INegBackup.importarDesdeArchivoPermiso
            Dim oIOBackup As New IO.SIS.ESCRITURA.IOBackup
            Dim listaPermiso As New List(Of BE.SIS.ENTIDAD.Permiso)

            listaPermiso = oIOBackup.leerArchivoPermiso(ruta, delim)

            Me.insertarPermisoDesdeBackup(listaPermiso)
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <remarks></remarks>
        Sub importarDesdeArchivoMultiIdioma(ByVal ruta As String, ByVal delim As String) Implements INegBackup.importarDesdeArchivoMultiIdioma
            Dim oIOBackup As New IO.SIS.ESCRITURA.IOBackup
            Dim listaMultiIdioma As New List(Of BE.SIS.ENTIDAD.MultiIdioma)

            listaMultiIdioma = oIOBackup.leerArchivoMultiIdioma(ruta, delim)

            Me.insertarMultiIdiomaDesdeBackup(listaMultiIdioma)
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <remarks></remarks>
        Sub importarDesdeArchivoUsuarioGrupo(ByVal ruta As String, ByVal delim As String) Implements INegBackup.importarDesdeArchivoUsuarioGrupo
            Dim oIOBackup As New IO.SIS.ESCRITURA.IOBackup
            Dim listaUsuarioGrupo As New List(Of BE.SIS.ENTIDAD.UsuarioGrupo)

            listaUsuarioGrupo = oIOBackup.leerArchivoUsuarioGrupo(ruta, delim)

            Me.insertarUsuarioGrupoDesdeBackup(listaUsuarioGrupo)
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="listaUsuarios"></param>
        ''' <remarks></remarks>
        Public Sub insertarUsuarioDesdeBackup(ByVal listaUsuarios As List(Of BE.SIS.ENTIDAD.Usuario)) Implements INegBackup.insertarUsuarioDesdeBackup
            Dim oDalUsuario As New DAL.SIS.DATOS.DALUsuario

            oDalUsuario.insertarUsuarioDesdeBackup(listaUsuarios)

        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="listaEventos"></param>
        ''' <remarks></remarks>
        Public Sub insertarBitacoraDesdeBackup(ByVal listaEventos As List(Of BE.SIS.ENTIDAD.Bitacora)) Implements INegBackup.insertarBitacoraDesdeBackup
            Dim oDalBitacora As New DAL.SIS.DATOS.DALBitacora

            oDalBitacora.insertarBitacoraDesdeBackup(listaEventos)

        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="listaGrupo"></param>
        ''' <remarks></remarks>
        Public Sub insertarGrupoDesdeBackup(ByVal listaGrupo As List(Of BE.SIS.ENTIDAD.Grupo)) Implements INegBackup.insertarGrupoDesdeBackup
            Dim oDalBitacora As New DAL.SIS.DATOS.DALBitacora

            oDalBitacora.insertarGrupoDesdeBackup(listaGrupo)

        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="listaGrupoPermiso"></param>
        ''' <remarks></remarks>
        Public Sub insertarGrupoPermisoDesdeBackup(ByVal listaGrupoPermiso As List(Of BE.SIS.ENTIDAD.GrupoPermiso)) Implements INegBackup.insertarGrupoPermisoDesdeBackup
            Dim oDalBitacora As New DAL.SIS.DATOS.DALBitacora

            oDalBitacora.insertarGrupoPermisoDesdeBackup(listaGrupoPermiso)

        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="listaMultiIdioma"></param>
        ''' <remarks></remarks>
        Public Sub insertarMultiIdiomaDesdeBackup(ByVal listaMultiIdioma As List(Of BE.SIS.ENTIDAD.MultiIdioma)) Implements INegBackup.insertarMultiIdiomaDesdeBackup
            Dim oDalBitacora As New DAL.SIS.DATOS.DALBitacora

            oDalBitacora.insertarMultiIdiomaDesdeBackup(listaMultiIdioma)

        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="listaPermiso"></param>
        ''' <remarks></remarks>
        Public Sub insertarPermisoDesdeBackup(ByVal listaPermiso As List(Of BE.SIS.ENTIDAD.Permiso)) Implements INegBackup.insertarPermisoDesdeBackup
            Dim oDalBitacora As New DAL.SIS.DATOS.DALBitacora

            oDalBitacora.insertarPermisoDesdeBackup(listaPermiso)

        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="listaUsuarioGrupo"></param>
        ''' <remarks></remarks>
        Public Sub insertarUsuarioGrupoDesdeBackup(ByVal listaUsuarioGrupo As List(Of BE.SIS.ENTIDAD.UsuarioGrupo)) Implements INegBackup.insertarUsuarioGrupoDesdeBackup
            Dim oDalBitacora As New DAL.SIS.DATOS.DALBitacora

            oDalBitacora.insertarUsuarioGrupoDesdeBackup(listaUsuarioGrupo)

        End Sub
    End Class
End Namespace