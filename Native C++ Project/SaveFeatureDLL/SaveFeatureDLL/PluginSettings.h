#pragma once

#ifdef PLUGIN_EXPORT
#define PLUGIN_API __declspec(dllexport)
#elif PLUGIN_IMPORT
#define PLUGIN_API __declspec(dllimport)
#else
#define PLUGIN_API
#endif 