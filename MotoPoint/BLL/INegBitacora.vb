Imports EL
Imports BE

Namespace SIS.BUSINESS
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Interface INegBitacora
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="usuarioId"></param>
        ''' <param name="oBKP"></param>
        ''' <remarks></remarks>
        Sub registrarEnBitacora_BKP(ByVal usuarioId As String, ByVal oBKP As EL.SIS.EXCEPCIONES.BKPException)
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="usuarioId"></param>
        ''' <param name="oBLL"></param>
        ''' <remarks></remarks>
        Sub registrarEnBitacora_BLL(ByVal usuarioId As String, ByVal oBLL As EL.SIS.EXCEPCIONES.BLLExcepcion)
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="usuarioId"></param>
        ''' <param name="oDAL"></param>
        ''' <remarks></remarks>
        Sub registrarEnBitacora_DAL(ByVal usuarioId As String, ByVal oDAL As EL.SIS.EXCEPCIONES.DALExcepcion)
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="usuarioId"></param>
        ''' <param name="oIO"></param>
        ''' <remarks></remarks>
        Sub registrarEnBitacora_IO(ByVal usuarioId As String, ByVal oIO As EL.SIS.EXCEPCIONES.IOException)
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="usuarioId"></param>
        ''' <param name="oSEG"></param>
        ''' <remarks></remarks>
        Sub registrarEnBitacora_SEG(ByVal usuarioId As String, ByVal oSEG As EL.SIS.EXCEPCIONES.SEGExcepcion)
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="usuarioId"></param>
        ''' <param name="oUI"></param>
        Sub registrarEnBitacora_UI(ByVal usuarioId As String, ByVal oUI As EL.SIS.EXCEPCIONES.UIExcepcion)
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function obtenerEventosBitacora() As List(Of BE.SIS.ENTIDAD.Bitacora)
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function verificarConsistenciaBD() As Boolean
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function obtenerLogSystem() As DataTable
    End Interface
End Namespace
