Imports System.Security
Imports System.Security.Cryptography
Imports System.Text
Imports BE
Imports DAL
Imports EL

Namespace SIS.IO
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Hash
        Implements IHash
        ''' <summary>
        ''' 
        ''' </summary>
        Dim interfazIOBitacora As ESCRITURA.IOBitacora = New ESCRITURA.IOBitacora
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="sCadena"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function generarSHA(ByVal sCadena As String) As String Implements IHash.generarSHA

            ' Objeto de codificación
            Dim ueCodigo As New UnicodeEncoding()

            ' Objeto para instanciar las codificación
            Dim SHA As New SHA256Managed

            ' Calcula el valor hash de la cadena recibida
            Dim bHash() As Byte = SHA.ComputeHash(ueCodigo.GetBytes(sCadena))

            ' Convierte el hash en una cadena y lo devuelve
            Return Convert.ToBase64String(bHash)
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="cadena"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function obtenerHash(ByVal cadena As String) As String Implements IHash.obtenerHash
            Dim cadenaHasheada As String

            Dim interfazHash As IHash = New Hash
            cadenaHasheada = interfazHash.generarSHA(cadena)

            Return cadenaHasheada
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="oUsuario"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function obtenerHashUsuario(ByVal oUsuario As BE.SIS.ENTIDAD.Usuario) As String Implements IHash.obtenerHashUsuario
            Dim digiVerif As String = "ERROR"

            Dim cadena As String
            cadena = oUsuario.idUsuario.ToString + oUsuario.usuario + oUsuario.password + oUsuario.legajo.ToString + oUsuario.idioma.ToString

            digiVerif = Me.obtenerHash(cadena)

            Return digiVerif
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function verificarConsistenciaUsuarioBD() As Boolean Implements IHash.verificarConsistenciaUsuarioBD
            Dim resultadoVerificacion As Boolean
            Dim resultado As Integer
            Dim cadena As String
            Dim cadenaHasheada As String
            Dim hashVerificador As String
            Dim contadorErroneo As Integer = 0
            Dim listaUsuarios As New List(Of BE.SIS.ENTIDAD.Usuario)

            Dim oDalUsuario As New DAL.SIS.DATOS.DALUsuario

            Try
                listaUsuarios = oDalUsuario.obtenerTablaUsuario
            Catch ex As EL.SIS.EXCEPCIONES.DALExcepcion
                Throw New EL.SIS.EXCEPCIONES.BLLExcepcion(ex.Message)
            End Try
            '#################### DIGITO VERIFICADOR HORIZONTAL ####################
            Dim enu As IEnumerator(Of BE.SIS.ENTIDAD.Usuario) = listaUsuarios.GetEnumerator
            While enu.MoveNext
                cadena = ""
                cadenaHasheada = ""
                cadena = enu.Current.idUsuario.ToString + enu.Current.usuario + enu.Current.password + enu.Current.legajo + enu.Current.idioma
                cadenaHasheada = Me.obtenerHash(cadena)
                hashVerificador = enu.Current.digitoVerificador

                resultado = cadenaHasheada.CompareTo(hashVerificador)
                If resultado = -1 Then
                    contadorErroneo = contadorErroneo + 1
                End If
            End While

            '#################### DIGITO VERIFICADOR VERTICAL ####################
            Dim bandera As Integer = 1

            Dim columnaUsuario As String = ""
            Dim columnaPassword As String = ""
            Dim columnaLegajo As String = ""
            Dim columnaIdioma As String = ""

            Dim columnaUsuarioHasheada As String = ""
            Dim columnaPasswordHasheada As String = ""
            Dim columnaLegajoHasheada As String = ""
            Dim columnaIdiomaHasheada As String = ""

            Dim columDigiUsuario As String = ""
            Dim columDigiPassword As String = ""
            Dim columDigiLegajo As String = ""
            Dim columDigiIdioma As String = ""

            Dim enuVert As IEnumerator(Of BE.SIS.ENTIDAD.Usuario) = listaUsuarios.GetEnumerator
            While enuVert.MoveNext
                If bandera = 1 Then
                    columDigiUsuario = enuVert.Current.usuario
                    columDigiPassword = enuVert.Current.password
                    columDigiLegajo = enuVert.Current.legajo.ToString
                    columDigiIdioma = enuVert.Current.idioma.ToString
                    bandera = 2
                Else
                    columnaUsuario = columnaUsuario + enuVert.Current.usuario
                    columnaPassword = columnaPassword + enuVert.Current.password
                    columnaLegajo = columnaLegajo + enuVert.Current.legajo.ToString
                    columnaIdioma = columnaIdioma + enuVert.Current.idioma.ToString
                End If
            End While

            columnaUsuarioHasheada = Me.obtenerHash(columnaUsuario)
            resultado = columnaUsuarioHasheada.CompareTo(columDigiUsuario)
            If resultado = 1 Then
                contadorErroneo = contadorErroneo + 1
                interfazIOBitacora.registrarLogSystem("TBL_USUARIO", "COL_USUARIOS")
            End If

            columnaPasswordHasheada = Me.obtenerHash(columnaPassword)
            resultado = columnaPasswordHasheada.CompareTo(columDigiPassword)
            If resultado = 1 Then
                contadorErroneo = contadorErroneo + 1
                interfazIOBitacora.registrarLogSystem("TBL_USUARIO", "COL_PASSWORD")
            End If

            columnaLegajoHasheada = Me.obtenerHash(columnaLegajo)
            resultado = columnaLegajoHasheada.CompareTo(columDigiLegajo)
            If resultado = 1 Then
                contadorErroneo = contadorErroneo + 1
                interfazIOBitacora.registrarLogSystem("TBL_USUARIO", "COL_LEGAJO")
            End If

            columnaIdiomaHasheada = Me.obtenerHash(columnaIdioma)
            resultado = columnaIdiomaHasheada.CompareTo(columDigiIdioma)
            If resultado = 1 Then
                contadorErroneo = contadorErroneo + 1
                interfazIOBitacora.registrarLogSystem("TBL_USUARIO", "COL_IDIOMA")
            End If

            '###### EVALUACION FINAL ######
            'Evaluación final para saber si hubo algun error de comprobación
            'en los digitos verificadores tanto verticales como horizontales.

            If contadorErroneo = 0 Then
                resultadoVerificacion = True
            Else
                resultadoVerificacion = False
                'FIXME
                'Throw New EL.SIS.EXCEPCIONES.BLLExcepcion("Inconsistencia en Base de Datos - Digito Verificador Invalido")
            End If

            Return resultadoVerificacion
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function verificarConsistenciaBitacoraBD() As Boolean Implements IHash.verificarConsistenciaBitacoraBD
            Dim resultadoVerificacion As Boolean
            Dim resultado As Integer
            Dim cadena As String
            Dim cadenaHasheada As String
            Dim hashVerificador As String
            Dim contadorErroneo As Integer = 0
            Dim listaBitacora As New List(Of BE.SIS.ENTIDAD.Bitacora)

            Dim oDalBitacora As New DAL.SIS.DATOS.DALBitacora

            Try
                listaBitacora = oDalBitacora.obtenerTablaBitacora
            Catch ex As EL.SIS.EXCEPCIONES.DALExcepcion
                Throw New EL.SIS.EXCEPCIONES.BLLExcepcion(ex.Message)
            End Try
            '#################### DIGITO VERIFICADOR HORIZONTAL ####################
            Dim enu As IEnumerator(Of BE.SIS.ENTIDAD.Bitacora) = listaBitacora.GetEnumerator
            While enu.MoveNext
                cadena = ""
                cadenaHasheada = ""
                cadena = enu.Current.idEvento.ToString + enu.Current.idUsuario + enu.Current.descripcion + enu.Current.fecha
                cadenaHasheada = Me.obtenerHash(cadena)
                hashVerificador = enu.Current.digitoVerificador

                resultado = cadenaHasheada.CompareTo(hashVerificador)
                If resultado = -1 Then
                    contadorErroneo = contadorErroneo + 1
                End If
            End While

            '#################### DIGITO VERIFICADOR VERTICAL ####################
            Dim bandera As Integer = 1

            Dim columnaIdUsuario As String = ""
            Dim columnaDescripcion As String = ""
            Dim columnaFecha As String = ""

            Dim columnaIdUsuarioHasheada As String = ""
            Dim columnaDescripciondHasheada As String = ""
            Dim columnaFechaHasheada As String = ""

            Dim columDigiIdUsuario As String = ""
            Dim columDigiDescripcion As String = ""
            Dim columDigiFecha As String = ""

            Dim enuVert As IEnumerator(Of BE.SIS.ENTIDAD.Bitacora) = listaBitacora.GetEnumerator
            While enuVert.MoveNext
                If bandera = 1 Then
                    columDigiIdUsuario = enuVert.Current.idUsuario
                    columDigiDescripcion = enuVert.Current.descripcion
                    columDigiFecha = enuVert.Current.fecha
                    bandera = 2
                Else
                    columnaIdUsuario = columnaIdUsuario + enuVert.Current.idUsuario
                    columnaDescripcion = columnaDescripcion + enuVert.Current.descripcion
                    columnaFecha = columnaFecha + enuVert.Current.fecha
                End If
            End While

            columnaIdUsuarioHasheada = Me.obtenerHash(columnaIdUsuario)
            resultado = columnaIdUsuarioHasheada.CompareTo(columDigiIdUsuario)
            If resultado = 1 Then
                contadorErroneo = contadorErroneo + 1
                interfazIOBitacora.registrarLogSystem("TBL_BITACORA", "COL_USUARIOS")
            End If

            columnaDescripciondHasheada = Me.obtenerHash(columnaDescripcion)
            resultado = columnaDescripciondHasheada.CompareTo(columDigiDescripcion)
            If resultado = 1 Then
                contadorErroneo = contadorErroneo + 1
                interfazIOBitacora.registrarLogSystem("TBL_BITACORA", "COL_DESCRIPCION")
            End If

            columnaFechaHasheada = Me.obtenerHash(columnaFechaHasheada)
            resultado = columnaFechaHasheada.CompareTo(columDigiFecha)
            If resultado = 1 Then
                contadorErroneo = contadorErroneo + 1
                interfazIOBitacora.registrarLogSystem("TBL_BITACORA", "COL_FECHA")
            End If

            '###### EVALUACION FINAL ######
            'Evaluación final para saber si hubo algun error de comprobación
            'en los digitos verificadores tanto verticales como horizontales.

            If contadorErroneo = 0 Then
                resultadoVerificacion = True
            Else
                resultadoVerificacion = False
                'FIXME
                'Throw New EL.SIS.EXCEPCIONES.BLLExcepcion("Inconsistencia en Base de Datos - Digito Verificador Invalido")
            End If

            Return resultadoVerificacion
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="oUsuario"></param>
        ''' <returns></returns>
        Function obtenerHashBitacora(ByVal oBitacora As BE.SIS.ENTIDAD.Bitacora) As String Implements IHash.obtenerHashBitacora
            Dim digiVerif As String = "ERROR"

            Dim cadena As String
            cadena = oBitacora.idEvento.ToString + oBitacora.idUsuario + oBitacora.descripcion + oBitacora.fecha

            digiVerif = Me.obtenerHash(cadena)

            Return digiVerif
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="listaUsuarios"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function calcularHashTablaUsuario(ByVal listaUsuarios As List(Of BE.SIS.ENTIDAD.Usuario)) As List(Of BE.SIS.ENTIDAD.Usuario) Implements IHash.calcularHashTablaUsuario
            Dim listaUsuarioHash As New List(Of BE.SIS.ENTIDAD.Usuario)

            '#################### DIGITO VERIFICADOR VERTICAL ####################
            Dim columnaIdUsuario As String = ""
            Dim columnaUsuario As String = ""
            Dim columnaPassword As String = ""
            Dim columnaLegajo As String = ""
            Dim columnaIdioma As String = ""

            Dim columDigiIdUsuario As String = ""
            Dim columDigiUsuario As String = ""
            Dim columDigiPassword As String = ""
            Dim columDigiLegajo As String = ""
            Dim columDigiIdioma As String = ""

            Dim enuVert As IEnumerator(Of BE.SIS.ENTIDAD.Usuario) = listaUsuarios.GetEnumerator
            While enuVert.MoveNext
                If enuVert.Current.idUsuario = 1 Then
                    'No hago nada porque es el registro de los digitos verificadores
                    'verticales totales.
                Else
                    columnaUsuario = columnaUsuario + enuVert.Current.usuario
                    columnaPassword = columnaPassword + enuVert.Current.password
                    columnaLegajo = columnaLegajo + enuVert.Current.legajo.ToString
                    columnaIdioma = columnaIdioma + enuVert.Current.idioma.ToString
                End If
            End While

            Dim enuVert2 As IEnumerator(Of BE.SIS.ENTIDAD.Usuario) = listaUsuarios.GetEnumerator
            While enuVert2.MoveNext
                If enuVert2.Current.idUsuario = 1 Then
                    'No hay digito verificador de la PK
                    enuVert2.Current.usuario = Me.obtenerHash(columnaUsuario)
                    enuVert2.Current.password = Me.obtenerHash(columnaPassword)
                    enuVert2.Current.legajo = Me.obtenerHash(columnaLegajo)
                    enuVert2.Current.idioma = Me.obtenerHash(columnaIdioma)
                End If
            End While

            listaUsuarioHash = listaUsuarios

            Dim cadena As String = ""
            Dim cadenaHasheada As String = ""

            '#################### DIGITO VERIFICADOR HORIZONTAL ####################
            Dim enu As IEnumerator(Of BE.SIS.ENTIDAD.Usuario) = listaUsuarios.GetEnumerator
            While enu.MoveNext
                cadena = ""
                cadenaHasheada = ""
                cadena = enu.Current.idUsuario.ToString + enu.Current.usuario + enu.Current.password + enu.Current.legajo + enu.Current.idioma
                cadenaHasheada = Me.obtenerHash(cadena)
                enu.Current.digitoVerificador = cadenaHasheada
            End While
            Return listaUsuarioHash
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        Function calcularHashTablaBitacora() Implements IHash.calcularHashTablaBitacora
            Dim oUpdateBitacora As New BE.SIS.ENTIDAD.Bitacora
            Dim oDalBitacora As New DAL.SIS.DATOS.DALBitacora
            Dim listaBitacora As New List(Of BE.SIS.ENTIDAD.Bitacora)

            Try
                listaBitacora = oDalBitacora.obtenerTablaBitacora
            Catch ex As EL.SIS.EXCEPCIONES.DALExcepcion
                Throw New EL.SIS.EXCEPCIONES.BLLExcepcion(ex.Message)
            End Try

            '#################### DIGITO VERIFICADOR VERTICAL ####################
            Dim bandera As Integer = 1

            Dim columnaIdUsuario As String = ""
            Dim columnaDescripcion As String = ""
            Dim columnaFecha As String = ""
            Dim columnaDigitoVerficador As String = ""

            Dim columnaIdUsuarioHasheada As String = ""
            Dim columnaDescripciondHasheada As String = ""
            Dim columnaFechaHasheada As String = ""
            Dim columnaDigitoVerficadorHasheada As String = ""

            Dim columDigiIdUsuario As String = ""
            Dim columDigiDescripcion As String = ""
            Dim columDigiFecha As String = ""
            Dim columnaDigiIdEvento As String = ""


            Dim enuVert As IEnumerator(Of BE.SIS.ENTIDAD.Bitacora) = listaBitacora.GetEnumerator
            While enuVert.MoveNext
                If bandera = 1 Then
                    columnaDigiIdEvento = enuVert.Current.idEvento.ToString
                    columDigiIdUsuario = enuVert.Current.idUsuario
                    columDigiDescripcion = enuVert.Current.descripcion
                    columDigiFecha = enuVert.Current.fecha
                    bandera = 2
                Else
                    columnaIdUsuario = columnaIdUsuario + enuVert.Current.idUsuario
                    columnaDescripcion = columnaDescripcion + enuVert.Current.descripcion
                    columnaFecha = columnaFecha + enuVert.Current.fecha
                End If
            End While

            'ARQ.BASE - CALCULAMOS LOS NUEVOS VALORES DE DIGITOS VERIFICADORES
            columnaIdUsuarioHasheada = Me.obtenerHash(columnaIdUsuario)
            columnaDescripciondHasheada = Me.obtenerHash(columnaDescripcion)
            columnaFechaHasheada = Me.obtenerHash(columnaFechaHasheada)

            Dim headerVerificador = columnaDigiIdEvento + columnaIdUsuarioHasheada + columnaDescripciondHasheada + columnaFechaHasheada
            columnaDigitoVerficadorHasheada = Me.obtenerHash(headerVerificador)


            oUpdateBitacora.idEvento = 1
            oUpdateBitacora.idUsuario = columnaIdUsuarioHasheada
            oUpdateBitacora.descripcion = columnaDescripciondHasheada
            oUpdateBitacora.fecha = columnaFechaHasheada
            oUpdateBitacora.digitoVerificador = columnaDigitoVerficadorHasheada

            'ARQ.BASE - ACTUALIZO LA TABLA DE BITACORA CON LOS DIG. VERIFICADORES
            oDalBitacora.actualizarDigitoVerificadorBitacora(oUpdateBitacora)

        End Function
    End Class
End Namespace

