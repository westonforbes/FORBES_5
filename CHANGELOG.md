# FORBES_5 Library Change Log

## Introduction

Revision Schema is ISO8601 (YYYY-MM-DD) followed by a two digit daily revision number.

## 2020-12-19-01

* Added CENTER extension to EXTENSIONS_NAMESPACE.STRING_EXTENSIONS.
* Added LOGGER features to EXTENSIONS_NAMESPACE.STRING_EXTENSIONS methods. Also added a LOGGER_ON  bit to turn it on and off.
* Also added a EXTENSIONS_TEST_APPLICATION.
* Modified LOGGER to not use EXTENSIONS_NAMESPACE.STRING_EXTENSIONS.TRUNCATE_AND_PAD because I added LOGGER features to TRUNCATE_AND_PAD and that would cause a recursive loop.

## 2020-12-18-01

* Added LOGGER_NAMESPACE which is a spiritual successor to LOGGER_NAMESPACE from the FORBES library based on .NET Framework 4.7.2 but its a completely different code base. Instead of logging stuff to a unwieldy DataTable this namespace utilizes the System.Diagnostics.Trace class to log directly to a log file.
* Added EXTENSIONS_NAMESPACE which contains commonly used type extension methods. At this initial revision it just includes TRUNCATE_AND_PAD which will trim and pad any text to a fixed length. Next I'd like to add a CENTER extension for strings.
* Added LOGGER features to ASCII_RENDER_NAMESPACE.

## 2020-12-17-01

* Initial revision. Library includes STOPWATCH_NAMESPACE and ASCII_RENDER_NAMESPACE.
* Both namespaces are stable, commented and have associated test applications.

### THE  BEGINNING