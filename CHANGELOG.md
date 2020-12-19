# FORBES Library Change Log

## Introduction

Revision Schema is ISO8601 (YYYY-MM-DD) followed by a two digit daily revision number.

## 2020-12-17-01

* Initial revision. Library includes STOPWATCH_NAMESPACE and ASCII_RENDER_NAMESPACE.
* Both namespaces are stable, commented and have associated test applications.

## 2020-12-18-01

* Added LOGGER_NAMESPACE which is a spiritual successor to LOGGER_NAMESPACE from the FORBES library based on .NET Framework 4.7.2 but its a completely different code base. Instead of logging stuff to a unwieldy DataTable this namespace utilizes the System.Diagnostics.Trace class to log directly to a log file.
* Added EXTENSIONS_NAMESPACE which contains commonly used type extension methods. At this initial revision it just includes TRUNCATE_AND_PAD which will trim and pad any text to a fixed length. Next I'd like to add a CENTER extension for strings.
* Added LOGGER features to ASCII_RENDER_NAMESPACE.