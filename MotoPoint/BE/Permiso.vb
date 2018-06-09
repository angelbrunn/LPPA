Namespace SIS.ENTIDAD
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Permiso
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Private idPermisoField As Integer
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property idPermiso() As Integer
            Get
                Return idPermisoField
            End Get
            Set(ByVal value As Integer)
                idPermisoField = value
            End Set
        End Property
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Private descripcionField As String
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property descripcion() As String
            Get
                Return descripcionField
            End Get
            Set(ByVal value As String)
                descripcionField = value
            End Set
        End Property
    End Class
End Namespace
