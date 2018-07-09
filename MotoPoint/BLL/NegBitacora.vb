Imports BL
Imports EL
Imports BE

Namespace SIS.BUSINESS
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class NegBitacora
        Implements INegBitacora
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Dim interfazHash As IO.SIS.IO.IHash = New IO.SIS.IO.Hash
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Dim interfazIOBitacora As IO.SIS.ESCRITURA.IOBitacora = New IO.SIS.ESCRITURA.IOBitacora
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="usuarioId"></param>
        ''' <param name="oBKP"></param>
        ''' <remarks></remarks>
        Sub registrarEnBitacora_BKP(ByVal usuarioId As String, ByVal oBKP As EL.SIS.EXCEPCIONES.BKPException) Implements INegBitacora.registrarEnBitacora_BKP
            Dim oBITBitacora As New BL.SIS.BIT.Bitacora
            oBITBitacora.registrarEnBitacora_BKP(usuarioId, oBKP)
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="usuarioId"></param>
        ''' <param name="oBLL"></param>
        ''' <remarks></remarks>
        Sub registrarEnBitacora_BLL(ByVal usuarioId As String, ByVal oBLL As EL.SIS.EXCEPCIONES.BLLExcepcion) Implements INegBitacora.registrarEnBitacora_BLL
            Dim oBITBitacora As New BL.SIS.BIT.Bitacora
            oBITBitacora.registrarEnBitacora_BLL(usuarioId, oBLL)
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="usuarioId"></param>
        ''' <param name="oDAL"></param>
        ''' <remarks></remarks>
        Sub registrarEnBitacora_DAL(ByVal usuarioId As String, ByVal oDAL As EL.SIS.EXCEPCIONES.DALExcepcion) Implements INegBitacora.registrarEnBitacora_DAL
            Dim oBITBitacora As New BL.SIS.BIT.Bitacora
            oBITBitacora.registrarEnBitacora_DAL(usuarioId, oDAL)
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="usuarioId"></param>
        ''' <param name="oIO"></param>
        ''' <remarks></remarks>
        Sub registrarEnBitacora_IO(ByVal usuarioId As String, ByVal oIO As EL.SIS.EXCEPCIONES.IOException) Implements INegBitacora.registrarEnBitacora_IO
            Dim oBITBitacora As New BL.SIS.BIT.Bitacora
            oBITBitacora.registrarEnBitacora_IO(usuarioId, oIO)
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="usuarioId"></param>
        ''' <param name="oSEG"></param>
        ''' <remarks></remarks>
        Sub registrarEnBitacora_SEG(ByVal usuarioId As String, ByVal oSEG As EL.SIS.EXCEPCIONES.SEGExcepcion) Implements INegBitacora.registrarEnBitacora_SEG
            Dim oBITBitacora As New BL.SIS.BIT.Bitacora
            oBITBitacora.registrarEnBitacora_SEG(usuarioId, oSEG)
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="usuarioId"></param>
        ''' <param name="oUI"></param>
        Sub registrarEnBitacora_UI(ByVal usuarioId As String, ByVal oUI As EL.SIS.EXCEPCIONES.UIExcepcion) Implements INegBitacora.registrarEnBitacora_UI
            Dim oBITBitacora As New BL.SIS.BIT.Bitacora
            oBITBitacora.registrarEnBitacora_UI(usuarioId, oUI)
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function obtenerEventosBitacora() As List(Of BE.SIS.ENTIDAD.Bitacora) Implements INegBitacora.obtenerEventosBitacora
            Dim listadoEventos As New List(Of BE.SIS.ENTIDAD.Bitacora)

            Dim oBITBitacora As New BL.SIS.BIT.Bitacora
            listadoEventos = oBITBitacora.obtenerEventos

            Return listadoEventos
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function verificarConsistenciaBD() As Boolean Implements INegBitacora.verificarConsistenciaBD
            Dim estado As Boolean
            Dim IdDB As String = "DB"
            Try
                estado = interfazHash.verificarConsistenciaBitacoraBD()
            Catch ex As EL.SIS.EXCEPCIONES.SEGExcepcion
                registrarEnBitacora_SEG(IdDB, ex)
            End Try
            Return estado
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        Function obtenerLogSystem() As DataTable Implements INegBitacora.obtenerLogSystem
            Dim dt As DataTable
            Dim IdFile As String = "Error en lectura de log_System"
            Try
                dt = interfazIOBitacora.leerLogSystem()
            Catch ex As EL.SIS.EXCEPCIONES.SEGExcepcion
                registrarEnBitacora_SEG(IdFile, ex)
            End Try
            Return dt
        End Function
    End Class
End Namespace
