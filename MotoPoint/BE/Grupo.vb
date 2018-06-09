Namespace SIS.ENTIDAD
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Grupo
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
        Private grupoField As String
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property grupo() As String
            Get
                Return grupoField
            End Get
            Set(ByVal value As String)
                grupoField = value
            End Set
        End Property
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Private descripcionField As String
        Public Property descripcion() As String
            Get
                Return descripcionField
            End Get
            Set(ByVal value As String)
                descripcionField = value
            End Set
        End Property
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Private listadoPermisosField As List(Of Permiso)
        Public Property listadoPermisos() As List(Of Permiso)
            Get
                Return listadoPermisosField
            End Get
            Set(ByVal value As List(Of Permiso))
                listadoPermisosField = value
            End Set
        End Property
    End Class
End Namespace
