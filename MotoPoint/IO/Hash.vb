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
        Function verificarConsistenciaBD() As Boolean Implements IHash.verificarConsistenciaBD
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
            End If

            columnaPasswordHasheada = Me.obtenerHash(columnaPassword)
            resultado = columnaPasswordHasheada.CompareTo(columDigiPassword)
            If resultado = 1 Then
                contadorErroneo = contadorErroneo + 1
            End If

            columnaLegajoHasheada = Me.obtenerHash(columnaLegajo)
            resultado = columnaLegajoHasheada.CompareTo(columDigiLegajo)
            If resultado = 1 Then
                contadorErroneo = contadorErroneo + 1
            End If

            columnaIdiomaHasheada = Me.obtenerHash(columnaIdioma)
            resultado = columnaIdiomaHasheada.CompareTo(columDigiIdioma)
            If resultado = 1 Then
                contadorErroneo = contadorErroneo + 1
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
    End Class
End Namespace

