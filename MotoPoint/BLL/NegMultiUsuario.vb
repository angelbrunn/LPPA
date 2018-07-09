Imports IO
Imports BE
Imports DAL
Imports EL

Namespace SIS.BUSINESS
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class NegMultiUsuario
        Implements INegMultiUsuario
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Dim interfazHash As IO.SIS.IO.IHash = New IO.SIS.IO.Hash
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Dim interfazNegocioBitacora As INegBitacora = New NegBitacora
        '##### USUARIO ######
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="oUsuario"></param>
        ''' <remarks></remarks>
        Public Sub insertarUsuario(ByVal oUsuario As BE.SIS.ENTIDAD.Usuario) Implements INegMultiUsuario.insertarUsuario

            Dim passHasheada As String
            Dim digiVerificador As String
            Dim IdHASH As String = "HASH"
            'passHasheada = interfazHash.obtenerHash(oUsuario.password)
            'oUsuario.password = passHasheada

            'digiVerificador = interfazHash.obtenerHashUsuario(oUsuario)
            'oUsuario.digitoVerificador = digiVerificador
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Try
                passHasheada = interfazHash.obtenerHash(oUsuario.password)
                oUsuario.password = passHasheada

                digiVerificador = interfazHash.obtenerHashUsuario(oUsuario)
                oUsuario.digitoVerificador = digiVerificador
            Catch ex As Exception
                interfazNegocioBitacora.registrarEnBitacora_BLL(IdHASH, ex)
            End Try
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim listaUsuarios As New List(Of BE.SIS.ENTIDAD.Usuario)
            Dim oDalUsuaio As New DAL.SIS.DATOS.DALUsuario
            listaUsuarios = oDalUsuaio.obtenerTablaUsuario()
            If listaUsuarios.Count = 0 Then
                Dim oUsuarioColumnHash As New BE.SIS.ENTIDAD.Usuario
                oUsuarioColumnHash.idUsuario = 1
                oUsuarioColumnHash.usuario = "a"
                oUsuarioColumnHash.password = "a"
                oUsuarioColumnHash.legajo = "a"
                oUsuarioColumnHash.idioma = True
                listaUsuarios.Add(oUsuarioColumnHash)
            End If

            listaUsuarios.Add(oUsuario)

            Dim listaUsuariosConDigitosVerif As New List(Of BE.SIS.ENTIDAD.Usuario)
            listaUsuariosConDigitosVerif = interfazHash.calcularHashTablaUsuario(listaUsuarios)

            oDalUsuaio.insertarUsuario(listaUsuariosConDigitosVerif)

            Dim oDalUsuarioGrupo As New DAL.SIS.DATOS.DALUsuarioGrupo
            Dim listadoGruposAUsuario As List(Of BE.SIS.ENTIDAD.Grupo) = oUsuario.listadoGrupos
            Dim enu As IEnumerator(Of BE.SIS.ENTIDAD.Grupo) = listadoGruposAUsuario.GetEnumerator
            While enu.MoveNext
                Dim oUsuarioGrupo As New BE.SIS.ENTIDAD.UsuarioGrupo
                oUsuarioGrupo.idUsuario = oUsuario.idUsuario
                oUsuarioGrupo.idGrupo = enu.Current.idGrupo
                oDalUsuarioGrupo.insertarUsuarioGrupo(oUsuarioGrupo)
            End While
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function obtenerIdParaUsuario() As Integer Implements INegMultiUsuario.obtenerIdParaUsuario
            Dim ultimoIdUsuario As Integer

            Dim oDalUsuario As New DAL.SIS.DATOS.DALUsuario
            ultimoIdUsuario = oDalUsuario.obtenerUltimoId

            If ultimoIdUsuario = 0 Then
                ultimoIdUsuario = 1
            End If

            ultimoIdUsuario = ultimoIdUsuario + 1

            Return ultimoIdUsuario
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="idUsuario"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function obtenerUsuario(ByVal idUsuario As Integer) As BE.SIS.ENTIDAD.Usuario Implements INegMultiUsuario.obtenerUsuario
            'Instancio el usuario que voy a pasar por parametro
            Dim oUsuario As New BE.SIS.ENTIDAD.Usuario

            'Instancio DAL Usuario para obtener el usuario
            Dim oDalUsuario As New DAL.SIS.DATOS.DALUsuario
            oUsuario = oDalUsuario.obtenerUsuarioPorId(idUsuario)

            'Instancio el objeto UsuarioGrupo para buscar los grupos de ese usuario
            Dim oDalUsuarioGrupo As New DAL.SIS.DATOS.DALUsuarioGrupo
            Dim listaUsuarioGrupo As List(Of BE.SIS.ENTIDAD.UsuarioGrupo)
            listaUsuarioGrupo = oDalUsuarioGrupo.obtenerGrupoPorIdUsuario(idUsuario)

            ' Instancio una lista de grupos para el usuario
            Dim listaGrupo As New List(Of BE.SIS.ENTIDAD.Grupo)
            Dim listaPermisos As New List(Of BE.SIS.ENTIDAD.Permiso)

            'Recorro la lista y obtengo los objetos Grupo
            Dim enu As IEnumerator(Of BE.SIS.ENTIDAD.UsuarioGrupo) = listaUsuarioGrupo.GetEnumerator
            While enu.MoveNext
                Dim oGrupo As New BE.SIS.ENTIDAD.Grupo
                Dim oDalGrupo As New DAL.SIS.DATOS.DALGrupo
                oGrupo = oDalGrupo.obtenerGrupoPorId(enu.Current.idGrupo)

                Dim oDalGrupoPermiso As New DAL.SIS.DATOS.DALGrupoPermiso
                Dim listadoGrupoPermisos As New List(Of BE.SIS.ENTIDAD.GrupoPermiso)
                listadoGrupoPermisos = oDalGrupoPermiso.obtenerPermisosPorIdGrupo(oGrupo.idGrupo)

                Dim enu2 As IEnumerator(Of BE.SIS.ENTIDAD.GrupoPermiso) = listadoGrupoPermisos.GetEnumerator
                While enu2.MoveNext
                    Dim oDalPermiso As New DAL.SIS.DATOS.DALPermiso
                    Dim oPermiso As BE.SIS.ENTIDAD.Permiso
                    oPermiso = oDalPermiso.obtenerPermisoPorId(enu2.Current.idPermiso)
                    listaPermisos.Add(oPermiso)
                    oGrupo.listadoPermisos = listaPermisos
                End While
                listaGrupo.Add(oGrupo)
            End While
            oUsuario.listadoGrupos = listaGrupo

            Return oUsuario
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="legajo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function obtenerUsuarioPorLegajo(ByVal legajo As Integer) As BE.SIS.ENTIDAD.Usuario Implements INegMultiUsuario.obtenerUsuarioPorLegajo
            Dim oUsuario As New BE.SIS.ENTIDAD.Usuario
            Dim oDalUsuario As New DAL.SIS.DATOS.DALUsuario

            oUsuario = oDalUsuario.obtenerUsuarioPorLegajo(legajo)

            'Instancio el objeto UsuarioGrupo para buscar los grupos de ese usuario
            Dim oDalUsuarioGrupo As New DAL.SIS.DATOS.DALUsuarioGrupo
            Dim listaUsuarioGrupo As List(Of BE.SIS.ENTIDAD.UsuarioGrupo)
            listaUsuarioGrupo = oDalUsuarioGrupo.obtenerGrupoPorIdUsuario(oUsuario.idUsuario)

            ' Instancio una lista de grupos para el usuario
            Dim listaGrupo As New List(Of BE.SIS.ENTIDAD.Grupo)
            Dim listaPermisos As New List(Of BE.SIS.ENTIDAD.Permiso)

            'Recorro la lista y obtengo los objetos Grupo
            Dim enu As IEnumerator(Of BE.SIS.ENTIDAD.UsuarioGrupo) = listaUsuarioGrupo.GetEnumerator
            While enu.MoveNext
                Dim oGrupo As New BE.SIS.ENTIDAD.Grupo
                Dim oDalGrupo As New DAL.SIS.DATOS.DALGrupo
                oGrupo = oDalGrupo.obtenerGrupoPorId(enu.Current.idGrupo)

                Dim oDalGrupoPermiso As New DAL.SIS.DATOS.DALGrupoPermiso
                Dim listadoGrupoPermisos As New List(Of BE.SIS.ENTIDAD.GrupoPermiso)
                listadoGrupoPermisos = oDalGrupoPermiso.obtenerPermisosPorIdGrupo(oGrupo.idGrupo)

                Dim enu2 As IEnumerator(Of BE.SIS.ENTIDAD.GrupoPermiso) = listadoGrupoPermisos.GetEnumerator
                While enu2.MoveNext
                    Dim oDalPermiso As New DAL.SIS.DATOS.DALPermiso
                    Dim oPermiso As BE.SIS.ENTIDAD.Permiso
                    oPermiso = oDalPermiso.obtenerPermisoPorId(enu2.Current.idPermiso)
                    listaPermisos.Add(oPermiso)
                    oGrupo.listadoPermisos = listaPermisos
                End While
                listaGrupo.Add(oGrupo)
            End While
            oUsuario.listadoGrupos = listaGrupo

            Return oUsuario
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="usuario"></param>
        ''' <param name="password"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function login(ByVal usuario As String, ByVal password As String) As Integer Implements INegMultiUsuario.login
            'Cifro la password
            Dim passHasheada As String
            Dim resultadoValidacion As Integer = 0
            Dim oDalUsuario As New DAL.SIS.DATOS.DALUsuario
            Dim IdDB As String = "DB"

            Try
                passHasheada = interfazHash.obtenerHash(password)
                resultadoValidacion = oDalUsuario.validarUsuario(usuario, passHasheada)
            Catch ex As Exception
                interfazNegocioBitacora.registrarEnBitacora_BLL(IdDB, ex)
            End Try
            Return resultadoValidacion
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="usuario"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function validarExistenciaUsuario(ByVal usuario As String) As Boolean Implements INegMultiUsuario.validarExistenciaUsuario
            Dim resultado As Boolean = False

            Dim oDalUsuario As New DAL.SIS.DATOS.DALUsuario
            resultado = oDalUsuario.validarExistenciaUsuario(usuario)

            Return resultado
        End Function
        '##### GRUPO #####
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="idGrupo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function obtenerGrupoPorId(ByVal idGrupo As Integer) As BE.SIS.ENTIDAD.Grupo Implements INegMultiUsuario.obtenerGrupoPorId
            Dim oGrupo As New BE.SIS.ENTIDAD.Grupo

            Dim oDalGrupo As New DAL.SIS.DATOS.DALGrupo
            oGrupo = oDalGrupo.obtenerGrupoPorId(idGrupo)

            Return oGrupo
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function obtenerGrupos() As List(Of BE.SIS.ENTIDAD.Grupo) Implements INegMultiUsuario.obtenerGrupos
            Dim listadoGrupos As New List(Of BE.SIS.ENTIDAD.Grupo)

            Dim oDalGrupo As New DAL.SIS.DATOS.DALGrupo
            listadoGrupos = oDalGrupo.obtenerGrupos

            Return listadoGrupos
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="nombreGrupo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function obtenerDescripcionGrupoPorNombre(ByVal nombreGrupo As String) As String Implements INegMultiUsuario.obtenerDescripcionGrupoPorNombre
            Dim descripcionGrupo As String

            Dim oDalGrupo As New DAL.SIS.DATOS.DALGrupo
            descripcionGrupo = oDalGrupo.obtenerDescripcionGrupoPorNombreGrupo(nombreGrupo)

            Return descripcionGrupo
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="nombreGrupo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function obtenerGrupoPorNombre(ByVal nombreGrupo As String) As BE.SIS.ENTIDAD.Grupo Implements INegMultiUsuario.obtenerGrupoPorNombre
            Dim oGrupo As New BE.SIS.ENTIDAD.Grupo

            Dim oDalGrupo As New DAL.SIS.DATOS.DALGrupo
            oGrupo = oDalGrupo.obtenerGrupoPorNombreGrupo(nombreGrupo)

            Return oGrupo
        End Function
        '##### PERMISO #####
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="idPermiso"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function obtenerPermisoPorId(ByVal idPermiso As Integer) As BE.SIS.ENTIDAD.Permiso Implements INegMultiUsuario.obtenerPermisoPorId
            Dim oPermiso As New BE.SIS.ENTIDAD.Permiso

            Dim oDalPermiso As New DAL.SIS.DATOS.DALPermiso
            oPermiso = oDalPermiso.obtenerPermisoPorId(idPermiso)

            Return oPermiso
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function verificarConsistenciaUsuarioBD() As Boolean Implements INegMultiUsuario.verificarConsistenciaUsuarioBD
            Dim estado As Boolean
            Dim IdDB As String = "DB"
            Try
                estado = interfazHash.verificarConsistenciaUsuarioBD()
            Catch ex As EL.SIS.EXCEPCIONES.SEGExcepcion
                interfazNegocioBitacora.registrarEnBitacora_SEG(IdDB, ex)
            End Try
            Return estado
        End Function
    End Class
End Namespace
