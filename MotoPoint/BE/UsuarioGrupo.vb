Namespace SIS.ENTIDAD
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class UsuarioGrupo
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Private idUsuarioField As Integer
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property idUsuario() As Integer
            Get
                Return idUsuarioField
            End Get
            Set(ByVal value As Integer)
                idUsuarioField = value
            End Set
        End Property
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Private idGrupoField As Integer
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property idGrupo() As Integer
            Get
                Return idGrupoField
            End Get
            Set(ByVal value As Integer)
                idGrupoField = value
            End Set
        End Property
    End Class
End Namespace