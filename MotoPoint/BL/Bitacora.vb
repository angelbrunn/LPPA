Imports DAL
Imports EL
Imports BE
Imports IO

Namespace SIS.BIT
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Bitacora
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function obtenerUltimoId() As Integer
            Dim ultimoId As Integer
            Dim oDalBitacora As New DAL.SIS.DATOS.DALBitacora
            Try
                ultimoId = oDalBitacora.obtenerUltimoId()
            Catch ex As Exception

            End Try
            Return ultimoId
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="usuarioI"></param>
        ''' <param name="oBKPExc"></param>
        ''' <remarks></remarks>
        Public Sub registrarEnBitacora_BKP(ByVal usuarioI As String, ByVal oBKPExc As EL.SIS.EXCEPCIONES.BKPException)
            Dim oBitacora As New BE.SIS.ENTIDAD.Bitacora
            'Guardo Usuario
            oBitacora.idUsuario = usuarioI
            'Se agrega la fecha del evento.
            oBitacora.fecha = DateTime.Now
            oBitacora.descripcion = "BKPException:" + oBKPExc.Message

            Try
                ' Obtengo el ultimo id para agregarselo al objeto oBitacora.
                oBitacora.idEvento = (Me.obtenerUltimoId() + 1)

                ' Realizo la insercion en la base de datos por medio de DALBitacora
                ' si hay una excepcion cualquier que no me permite ingresar el resgistro
                ' llamo a la insercion en el archivo local dentro de IOBitacora.
                Dim oDalBitacora As New DAL.SIS.DATOS.DALBitacora


                oDalBitacora.registrarEnBitacoraBD(oBitacora)
            Catch ex As Exception
                Dim oIOBitacora As New IO.SIS.ESCRITURA.IOBitacora
                oIOBitacora.registrarEnBitacoraIO(oBitacora)
            End Try

        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="usuarioI"></param>
        ''' <param name="oBLLExc"></param>
        ''' <remarks></remarks>
        Public Sub registrarEnBitacora_BLL(ByVal usuarioI As String, ByVal oBLLExc As EL.SIS.EXCEPCIONES.BLLExcepcion)
            Dim oBitacora As New BE.SIS.ENTIDAD.Bitacora
            'Guardo Usuario
            oBitacora.idUsuario = usuarioI
            'Se agrega la fecha del evento.
            oBitacora.fecha = DateTime.Now
            oBitacora.descripcion = "BLLExcepcion:" + oBLLExc.Message

            Try
                ' Obtengo el ultimo id para agregarselo al objeto oBitacora.
                oBitacora.idEvento = (Me.obtenerUltimoId() + 1)

                ' Realizo la insercion en la base de datos por medio de DALBitacora
                ' si hay una excepcion cualquier que no me permite ingresar el resgistro
                ' llamo a la insercion en el archivo local dentro de IOBitacora.
                Dim oDalBitacora As New DAL.SIS.DATOS.DALBitacora
                oDalBitacora.registrarEnBitacoraBD(oBitacora)
            Catch ex As Exception
                Dim oIOBitacora As New IO.SIS.ESCRITURA.IOBitacora
                oIOBitacora.registrarEnBitacoraIO(oBitacora)
            End Try
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="usuarioI"></param>
        ''' <param name="oDALExc"></param>
        ''' <remarks></remarks>
        Public Sub registrarEnBitacora_DAL(ByVal usuarioI As String, ByVal oDALExc As EL.SIS.EXCEPCIONES.DALExcepcion)
            Dim oBitacora As New BE.SIS.ENTIDAD.Bitacora
            'Guardo Usuario
            oBitacora.idUsuario = usuarioI
            'Se agrega la fecha del evento.
            oBitacora.fecha = DateTime.Now
            oBitacora.descripcion = "DALExcepcion:" + oDALExc.Message

            Try
                ' Obtengo el ultimo id para agregarselo al objeto oBitacora.
                oBitacora.idEvento = (Me.obtenerUltimoId() + 1)

                ' Realizo la insercion en la base de datos por medio de DALBitacora
                ' si hay una excepcion cualquier que no me permite ingresar el resgistro
                ' llamo a la insercion en el archivo local dentro de IOBitacora.
                Dim oDalBitacora As New DAL.SIS.DATOS.DALBitacora
                oDalBitacora.registrarEnBitacoraBD(oBitacora)
            Catch ex As Exception
                Dim oIOBitacora As New IO.SIS.ESCRITURA.IOBitacora
                oIOBitacora.registrarEnBitacoraIO(oBitacora)
            End Try
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="usuarioI"></param>
        ''' <param name="oIOExc"></param>
        ''' <remarks></remarks>
        Public Sub registrarEnBitacora_IO(ByVal usuarioI As String, ByVal oIOExc As EL.SIS.EXCEPCIONES.IOException)
            Dim oBitacora As New BE.SIS.ENTIDAD.Bitacora
            'Guardo Usuario
            oBitacora.idUsuario = usuarioI
            'Se agrega la fecha del evento.
            oBitacora.fecha = DateTime.Now
            oBitacora.descripcion = "IOException:" + oIOExc.Message

            Try
                ' Obtengo el ultimo id para agregarselo al objeto oBitacora.
                oBitacora.idEvento = (Me.obtenerUltimoId() + 1)

                ' Realizo la insercion en la base de datos por medio de DALBitacora
                ' si hay una excepcion cualquier que no me permite ingresar el resgistro
                ' llamo a la insercion en el archivo local dentro de IOBitacora.
                Dim oDalBitacora As New DAL.SIS.DATOS.DALBitacora
                oDalBitacora.registrarEnBitacoraBD(oBitacora)
            Catch ex As Exception
                Dim oIOBitacora As New IO.SIS.ESCRITURA.IOBitacora
                oIOBitacora.registrarEnBitacoraIO(oBitacora)
            End Try
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="usuarioI"></param>
        ''' <param name="oSEGExc"></param>
        ''' <remarks></remarks>
        Public Sub registrarEnBitacora_SEG(ByVal usuarioI As String, ByVal oSEGExc As EL.SIS.EXCEPCIONES.SEGExcepcion)
            Dim oBitacora As New BE.SIS.ENTIDAD.Bitacora
            'Guardo Usuario
            oBitacora.idUsuario = usuarioI
            'Se agrega la fecha del evento.
            oBitacora.fecha = DateTime.Now
            oBitacora.descripcion = "SEGExcepcion:" + oSEGExc.Message

            Try
                ' Obtengo el ultimo id para agregarselo al objeto oBitacora.
                oBitacora.idEvento = (Me.obtenerUltimoId() + 1)

                ' Realizo la insercion en la base de datos por medio de DALBitacora
                ' si hay una excepcion cualquier que no me permite ingresar el resgistro
                ' llamo a la insercion en el archivo local dentro de IOBitacora.
                Dim oDalBitacora As New DAL.SIS.DATOS.DALBitacora
                oDalBitacora.registrarEnBitacoraBD(oBitacora)
            Catch ex As Exception
                Dim oIOBitacora As New IO.SIS.ESCRITURA.IOBitacora
                oIOBitacora.registrarEnBitacoraIO(oBitacora)
            End Try
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="usuarioI"></param>
        ''' <param name="oUIExc"></param>
        Public Sub registrarEnBitacora_UI(ByVal usuarioI As String, ByVal oUIExc As EL.SIS.EXCEPCIONES.UIExcepcion)
            Dim oBitacora As New BE.SIS.ENTIDAD.Bitacora
            'Guardo Usuario
            oBitacora.idUsuario = usuarioI
            'Se agrega la fecha del evento.
            oBitacora.fecha = DateTime.Now
            oBitacora.descripcion = "UIExcepcion:" + oUIExc.Message

            Try
                ' Obtengo el ultimo id para agregarselo al objeto oBitacora.
                oBitacora.idEvento = (Me.obtenerUltimoId() + 1)

                ' Realizo la insercion en la base de datos por medio de DALBitacora
                ' si hay una excepcion cualquier que no me permite ingresar el resgistro
                ' llamo a la insercion en el archivo local dentro de IOBitacora.
                Dim oDalBitacora As New DAL.SIS.DATOS.DALBitacora
                oDalBitacora.registrarEnBitacoraBD(oBitacora)
            Catch ex As Exception
                Dim oIOBitacora As New IO.SIS.ESCRITURA.IOBitacora
                oIOBitacora.registrarEnBitacoraIO(oBitacora)
            End Try
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function obtenerEventos() As List(Of BE.SIS.ENTIDAD.Bitacora)
            Dim listado As New List(Of BE.SIS.ENTIDAD.Bitacora)

            Dim oDalBitacora As New DAL.SIS.DATOS.DALBitacora
            listado = oDalBitacora.obtenerEventos

            Return listado
        End Function
    End Class
End Namespace
