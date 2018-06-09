Namespace SIS.ENTIDAD
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class MultiIdioma
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Private componenteField As String
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property componente() As String
            Get
                Return componenteField
            End Get
            Set(ByVal value As String)
                componenteField = value
            End Set
        End Property
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Private iKeyField As String
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property iKey() As String
            Get
                Return iKeyField
            End Get
            Set(ByVal value As String)
                iKeyField = value
            End Set
        End Property
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Private ValueField As String
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property value() As String
            Get
                Return ValueField
            End Get
            Set(ByVal value As String)
                ValueField = value
            End Set
        End Property
    End Class
End Namespace
