Imports System.IO
Imports IO
Imports BE

Namespace SIS.ESCRITURA
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class IOBackup
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function leerArchivoUsuario(ByVal ruta As String, ByVal delim As String) As List(Of BE.SIS.ENTIDAD.Usuario)
            Dim lista As New List(Of BE.SIS.ENTIDAD.Usuario)

            Try
                Dim linea As String = ""
                Dim sr As New StreamReader(ruta)
                Dim contador As Integer = 0
                Do
                    linea = sr.ReadLine()
                    If Not linea = Nothing Then
                        If contador > 0 Then
                            Dim vec() As String = linea.Split(delim)
                            Dim oUsuario As New BE.SIS.ENTIDAD.Usuario

                            oUsuario.idUsuario = CType(vec(0), Integer)
                            oUsuario.usuario = CType(vec(1), String)
                            oUsuario.password = CType(vec(2), String)
                            oUsuario.legajo = CType(vec(3), String)
                            oUsuario.idioma = CType(vec(4), String)
                            oUsuario.digitoVerificador = CType(vec(5), String)
                            lista.Add(oUsuario)
                        End If
                    End If
                    contador = contador + 1

                Loop Until linea Is Nothing
                sr.Close()
            Catch ex As Exception
                'Throw New BKPException("Error leyendo el Archivo")
            End Try

            Return lista
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function leerArchivoBitacora(ByVal ruta As String, ByVal delim As String) As List(Of BE.SIS.ENTIDAD.Bitacora)
            Dim lista As New List(Of BE.SIS.ENTIDAD.Bitacora)

            Try
                Dim linea As String = ""
                Dim sr As New StreamReader(ruta)
                Dim contador As Integer = 0
                Do
                    linea = sr.ReadLine()
                    If Not linea = Nothing Then
                        If contador > 0 Then
                            Dim vec() As String = linea.Split(delim)
                            Dim oBitacora As New BE.SIS.ENTIDAD.Bitacora
                            oBitacora.idEvento = CType(vec(0), Integer)
                            oBitacora.idUsuario = CType(vec(1), String)
                            oBitacora.descripcion = CType(vec(2), String)
                            oBitacora.fecha = CType(vec(3), String)
                            oBitacora.digitoVerificador = CType(vec(4), String)
                            lista.Add(oBitacora)
                        End If
                    End If
                    contador = contador + 1

                Loop Until linea Is Nothing
                sr.Close()
            Catch ex As Exception
                'Throw New BKPException("Error leyendo el Archivo")
            End Try
            Return lista
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function leerArchivoGrupo(ByVal ruta As String, ByVal delim As String) As List(Of BE.SIS.ENTIDAD.Grupo)
            Dim lista As New List(Of BE.SIS.ENTIDAD.Grupo)

            Try
                Dim linea As String = ""
                Dim sr As New StreamReader(ruta)
                Dim contador As Integer = 0
                Do
                    linea = sr.ReadLine()
                    If Not linea = Nothing Then
                        If contador > 0 Then
                            Dim vec() As String = linea.Split(delim)
                            Dim oGrupo As New BE.SIS.ENTIDAD.Grupo
                            oGrupo.idGrupo = CType(vec(0), Integer)
                            oGrupo.grupo = CType(vec(1), String)
                            oGrupo.descripcion = CType(vec(2), String)
                            lista.Add(oGrupo)
                        End If
                    End If
                    contador = contador + 1

                Loop Until linea Is Nothing
                sr.Close()
            Catch ex As Exception
                'Throw New BKPException("Error leyendo el Archivo")
            End Try
            Return lista
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function leerArchivoGrupoPermiso(ByVal ruta As String, ByVal delim As String) As List(Of BE.SIS.ENTIDAD.GrupoPermiso)
            Dim lista As New List(Of BE.SIS.ENTIDAD.GrupoPermiso)

            Try
                Dim linea As String = ""
                Dim sr As New StreamReader(ruta)
                Dim contador As Integer = 0
                Do
                    linea = sr.ReadLine()
                    If Not linea = Nothing Then
                        If contador > 0 Then
                            Dim vec() As String = linea.Split(delim)
                            Dim oGrupoPermiso As New BE.SIS.ENTIDAD.GrupoPermiso
                            oGrupoPermiso.idGrupo = CType(vec(0), Integer)
                            oGrupoPermiso.idPermiso = CType(vec(1), Integer)
                            lista.Add(oGrupoPermiso)
                        End If
                    End If
                    contador = contador + 1

                Loop Until linea Is Nothing
                sr.Close()
            Catch ex As Exception
                'Throw New BKPException("Error leyendo el Archivo")
            End Try

            Return lista
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function leerArchivoPermiso(ByVal ruta As String, ByVal delim As String) As List(Of BE.SIS.ENTIDAD.Permiso)
            Dim lista As New List(Of BE.SIS.ENTIDAD.Permiso)

            Try
                Dim linea As String = ""
                Dim sr As New StreamReader(ruta)
                Dim contador As Integer = 0
                Do
                    linea = sr.ReadLine()
                    If Not linea = Nothing Then
                        If contador > 0 Then
                            Dim vec() As String = linea.Split(delim)
                            Dim oPermiso As New BE.SIS.ENTIDAD.Permiso
                            oPermiso.idPermiso = CType(vec(0), Integer)
                            oPermiso.descripcion = CType(vec(1), String)
                            lista.Add(oPermiso)
                        End If
                    End If
                    contador = contador + 1

                Loop Until linea Is Nothing
                sr.Close()
            Catch ex As Exception
                'Throw New BKPException("Error leyendo el Archivo")
            End Try

            Return lista
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function leerArchivoUsuarioGrupo(ByVal ruta As String, ByVal delim As String) As List(Of BE.SIS.ENTIDAD.UsuarioGrupo)
            Dim lista As New List(Of BE.SIS.ENTIDAD.UsuarioGrupo)

            Try
                Dim linea As String = ""
                Dim sr As New StreamReader(ruta)
                Dim contador As Integer = 0
                Do
                    linea = sr.ReadLine()
                    If Not linea = Nothing Then
                        If contador > 0 Then
                            Dim vec() As String = linea.Split(delim)
                            Dim oUsuarioGrupo As New BE.SIS.ENTIDAD.UsuarioGrupo
                            oUsuarioGrupo.idUsuario = CType(vec(0), Integer)
                            oUsuarioGrupo.idGrupo = CType(vec(1), Integer)
                            lista.Add(oUsuarioGrupo)
                        End If
                    End If
                    contador = contador + 1

                Loop Until linea Is Nothing
                sr.Close()
            Catch ex As Exception
                'Throw New BKPException("Error leyendo el Archivo")
            End Try

            Return lista
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function leerArchivoMultiIdioma(ByVal ruta As String, ByVal delim As String) As List(Of BE.SIS.ENTIDAD.MultiIdioma)
            Dim lista As New List(Of BE.SIS.ENTIDAD.MultiIdioma)

            Try
                Dim linea As String = ""
                Dim sr As New StreamReader(ruta)
                Dim contador As Integer = 0
                Do
                    linea = sr.ReadLine()
                    If Not linea = Nothing Then
                        If contador > 0 Then
                            Dim vec() As String = linea.Split(delim)
                            Dim oMultiIdioma As New BE.SIS.ENTIDAD.MultiIdioma
                            oMultiIdioma.componente = CType(vec(0), String)
                            oMultiIdioma.iKey = CType(vec(1), String)
                            oMultiIdioma.value = CType(vec(2), String)
                            lista.Add(oMultiIdioma)
                        End If
                    End If
                    contador = contador + 1

                Loop Until linea Is Nothing
                sr.Close()
            Catch ex As Exception
                'Throw New BKPException("Error leyendo el Archivo")
            End Try

            Return lista
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <param name="listaUsuario"></param>
        ''' <remarks></remarks>
        Public Sub escribirArchivoUsuario(ByVal ruta As String, ByVal delim As String, ByVal listaUsuario As List(Of BE.SIS.ENTIDAD.Usuario))

            'idUsuario;usuario;password;legajo;idioma;digitoVerificador
            Dim cabecera As String = "idUsuario;usuario;password;legajo;idioma;digitoVerificador"

            Dim sw As New StreamWriter(ruta)
            sw.WriteLine(cabecera)
            Dim linea As String

            Dim enumC As IEnumerator(Of BE.SIS.ENTIDAD.Usuario) = listaUsuario.GetEnumerator()
            While (enumC.MoveNext())
                linea = enumC.Current.idUsuario.ToString() + delim + enumC.Current.usuario _
                + delim + enumC.Current.password + delim + enumC.Current.legajo + delim +
                enumC.Current.idioma + delim + enumC.Current.digitoVerificador

                sw.WriteLine(linea)
            End While
            sw.Close()
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <param name="listaEventos"></param>
        ''' <remarks></remarks>
        Public Sub escribirArchivoBitacora(ByVal ruta As String, ByVal delim As String, ByVal listaEventos As List(Of BE.SIS.ENTIDAD.Bitacora))

            'idEvento;idUsuario;descripcion;fecha
            Dim cabecera As String = "idEvento;idUsuario;descripcion;fecha;digitoVerificador"

            Dim sw As New StreamWriter(ruta)
            sw.WriteLine(cabecera)
            Dim linea As String

            Dim enumC As IEnumerator(Of BE.SIS.ENTIDAD.Bitacora) = listaEventos.GetEnumerator()
            While (enumC.MoveNext())
                linea = enumC.Current.idEvento.ToString() + delim + enumC.Current.idUsuario.ToString _
                + delim + enumC.Current.descripcion.ToString + delim + enumC.Current.fecha.ToString + delim + enumC.Current.digitoVerificador.ToString

                sw.WriteLine(linea)
            End While
            sw.Close()
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <param name="listaUsuarioGrupo"></param>
        ''' <remarks></remarks>
        Public Sub escribirArchivoUsuarioGrupo(ByVal ruta As String, ByVal delim As String, ByVal listaUsuarioGrupo As List(Of BE.SIS.ENTIDAD.UsuarioGrupo))

            'idUsuario;idGrupo
            Dim cabecera As String = "idUsuario;idGrupo"

            Dim sw As New StreamWriter(ruta)
            sw.WriteLine(cabecera)
            Dim linea As String

            Dim enumC As IEnumerator(Of BE.SIS.ENTIDAD.UsuarioGrupo) = listaUsuarioGrupo.GetEnumerator()
            While (enumC.MoveNext())
                linea = enumC.Current.idUsuario.ToString() + delim + enumC.Current.idGrupo.ToString
                sw.WriteLine(linea)
            End While
            sw.Close()
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <param name="listaGrupo"></param>
        ''' <remarks></remarks>
        Public Sub escribirArchivoGrupo(ByVal ruta As String, ByVal delim As String, ByVal listaGrupo As List(Of BE.SIS.ENTIDAD.Grupo))

            'idUsuario;idGrupo
            Dim cabecera As String = "idGrupo;grupo;descripcion"

            Dim sw As New StreamWriter(ruta)
            sw.WriteLine(cabecera)
            Dim linea As String

            Dim enumC As IEnumerator(Of BE.SIS.ENTIDAD.Grupo) = listaGrupo.GetEnumerator()
            While (enumC.MoveNext())
                linea = enumC.Current.idGrupo.ToString() + delim + enumC.Current.grupo.ToString + delim + enumC.Current.descripcion.ToString
                sw.WriteLine(linea)
            End While
            sw.Close()
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <param name="listaGrupoPermiso"></param>
        ''' <remarks></remarks>
        Public Sub escribirArchivoGrupoPermiso(ByVal ruta As String, ByVal delim As String, ByVal listaGrupoPermiso As List(Of BE.SIS.ENTIDAD.GrupoPermiso))

            Dim cabecera As String = "idGrupo;idPermiso"

            Dim sw As New StreamWriter(ruta)
            sw.WriteLine(cabecera)
            Dim linea As String

            Dim enumC As IEnumerator(Of BE.SIS.ENTIDAD.GrupoPermiso) = listaGrupoPermiso.GetEnumerator()
            While (enumC.MoveNext())
                linea = enumC.Current.idGrupo.ToString() + delim + enumC.Current.idPermiso.ToString()
                sw.WriteLine(linea)
            End While
            sw.Close()
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <param name="listaPermiso"></param>
        ''' <remarks></remarks>
        Public Sub escribirArchivoPermiso(ByVal ruta As String, ByVal delim As String, ByVal listaPermiso As List(Of BE.SIS.ENTIDAD.Permiso))

            Dim cabecera As String = "idPermiso;descripcion"

            Dim sw As New StreamWriter(ruta)
            sw.WriteLine(cabecera)
            Dim linea As String

            Dim enumC As IEnumerator(Of BE.SIS.ENTIDAD.Permiso) = listaPermiso.GetEnumerator()
            While (enumC.MoveNext())
                linea = enumC.Current.idPermiso.ToString() + delim + enumC.Current.descripcion.ToString()
                sw.WriteLine(linea)
            End While
            sw.Close()
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ruta"></param>
        ''' <param name="delim"></param>
        ''' <param name="listaPermiso"></param>
        ''' <remarks></remarks>
        Public Sub escribirArchivoMultiIdioma(ByVal ruta As String, ByVal delim As String, ByVal listaPermiso As List(Of BE.SIS.ENTIDAD.MultiIdioma))

            Dim cabecera As String = "componente;idiomaEspanol;idiomaIngles"

            Dim sw As New StreamWriter(ruta)
            sw.WriteLine(cabecera)
            Dim linea As String

            Dim enumC As IEnumerator(Of BE.SIS.ENTIDAD.MultiIdioma) = listaPermiso.GetEnumerator()
            While (enumC.MoveNext())
                linea = enumC.Current.componente.ToString() + delim + enumC.Current.iKey.ToString() + delim + enumC.Current.value.ToString()
                sw.WriteLine(linea)
            End While
            sw.Close()
        End Sub
    End Class
End Namespace