@echo off
sqlcmd -S .\ -Q "CREATE DATABASE HRDemo"
sqlcmd -S .\ -d HRDemo -Q "USE HRDemo"
echo Database HRDemo created successfully.
