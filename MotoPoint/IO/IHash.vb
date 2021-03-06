﻿Imports System.Security
Imports System.Security.Cryptography
Imports System.Text
Imports BE

Namespace SIS.IO
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Interface IHash
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="sCadena"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function generarSHA(ByVal sCadena As String) As String
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="cadena"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function obtenerHash(ByVal cadena As String) As String
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="oUsuario"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function obtenerHashUsuario(ByVal oUsuario As BE.SIS.ENTIDAD.Usuario) As String
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="oBitacora"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function obtenerHashBitacora(ByVal oBitacora As BE.SIS.ENTIDAD.Bitacora) As String
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function verificarConsistenciaUsuarioBD() As Boolean
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function verificarConsistenciaBitacoraBD() As Boolean
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="listaUsuario"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function calcularHashTablaUsuario(ByVal listaUsuario As List(Of BE.SIS.ENTIDAD.Usuario)) As List(Of BE.SIS.ENTIDAD.Usuario)
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        Function calcularHashTablaBitacora()
    End Interface
End Namespace
