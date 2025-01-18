@echo off
sqlcmd -S .\SQLEXPRESS -Q "CREATE DATABASE HRDemo"
sqlcmd -S .\SQLEXPRESS -d HRDemo -Q "USE HRDemo"
echo Database HRDemo created successfully.
