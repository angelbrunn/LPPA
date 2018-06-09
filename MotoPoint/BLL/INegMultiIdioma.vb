Imports BE

Namespace SIS.BUSINESS
    Public Interface INegMultiIdioma
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function obtenerTablaMultiIdioma(ByVal idioma As String) As List(Of BE.SIS.ENTIDAD.MultiIdioma)
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function obtenerIdiomasDisponibles() As List(Of BE.SIS.ENTIDAD.MultiIdioma)
    End Interface
End Namespace