Namespace SIS.ENTIDAD
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class GrupoPermiso
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
    End Class
End Namespace