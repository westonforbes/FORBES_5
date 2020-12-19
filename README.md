# FORBES_5 Library Readme

## Introduction

This library contains methods and classes I've written that I find reusable and with broad application. It is a predecessor to my FORBES library which was built on .NET Framework 4.7.2. This library is developed for .NET 5 which belongs to the .NET Core family (rather than framework), so it made sense to kind of start fresh with a new library.

## Documentation Notes

All publicly accessible methods and objects are documented with XML documentation. This allows documentation to be viewed in the Visual Studio Object Browser and to work with IntelliSense. https://docs.microsoft.com/en-us/dotnet/csharp/codedoc

Private methods and objects are documented with traditional double-slash comments.

## Namespaces

### ASCII_RENDER_NAMESPACE

This namespace allows you to render images as ASCII art, its kind of a fun tool and may be useful to others. The included test application will render a dancing banana gif to the console. Its stupid but neat.

### STOPWATCH_NAMESPACE

This namespace contains the STOPWATCH class. Its a lightweight and clean way to do a stopwatch. Rather than using a Timer and the associated worker threads and resources, it just timestamps the start time and stop time and calculates the difference between the two. This leaves it open to problems like the clock being adjusted while its running causing issues, so ya know, don't run the space shuttle guidance computers on it, but other than that, meh. Its useful.

### LOGGER_NAMESPACE

This namespace handles everything needed for simple application logging. It will track and indent the methods being called and save everything to a log file located in the current directory.

### EXTENSIONS_NAMESPACE

Holds custom extensions for different data types. Just things I have found useful.