#pragma once

#include"framework.h"
#include <Shldisp.h>
#include<vector>
#include<shobjidl_core.h>
#include<shlobj.h>
#include<thumbcache.h>
#include<Shlwapi.h>
#include <strsafe.h>
#include<tchar.h>

#include"RegTool.h"

#define WM_SPAWN_WORKER 0x052C

//refrence https://github.com/TranslucentTB/TranslucentT
enum ACCENT_STATE :INT
{
	ACCENT_DISABLED = 0,
	ACCENT_ENABLE_GRADIENT = 1,
	ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
	ACCENT_ENABLE_BLURBEHIND =3,
	ACCENT_ENABLE_ACRYLICBLURBEHIND = 4
};

struct ACCENT_POLICY
{
	ACCENT_STATE AcentState;
	UINT AccentFlags;
	COLORREF GradientColor;
	LONG AnimationId;
};

enum WINDOWCOMPOSITIONATTRIB : INT
{
	WCA_ACCENT_POLICY = 0x13
};

struct WINDOWCOMPOSITIONATTRIBDATA
{
	WINDOWCOMPOSITIONATTRIB Attrib;
	LPVOID pvData;
	UINT cbData;
};

typedef struct tagTASKBARINFO
{
	int nTaskBarWidth;
	int nTaskBarHeight;
	int nTaskListWidth;
	int nStartMenuWidth;
	bool bDoubleTaskBar;
}TASKBARINFO, * PTASKBARINFO;

enum class DESKTOPICONS : INT
{
	ICON_COMPUTER,
	ICON_USER,
	ICON_RECYCLE,
	ICON_CONTROL_PANEL,
	ICON_NETWORK
};

typedef BOOL(WINAPI* PFN_SET_WINDOW_COMPOSITION_ATTRIBUTE)(HWND, const WINDOWCOMPOSITIONATTRIBDATA*);

SILVERAROWANACORE_API BOOL SetBackground(LPTSTR lpImagePath);
SILVERAROWANACORE_API BOOL GetBackground(LPTSTR lpImagePath);
SILVERAROWANACORE_API BOOL GetRecentBackground(LPTSTR lpRecentPath);
SILVERAROWANACORE_API VOID SwitchToDesktop();
SILVERAROWANACORE_API VOID SwitchToWindow(HWND hwnd);
SILVERAROWANACORE_API BOOL CloseEmbedWindow();
BOOL CALLBACK EnumWindowProc(HWND hwnd, LPARAM lParam);
SILVERAROWANACORE_API HBITMAP GetFileThumbnail(PCWSTR path);
SILVERAROWANACORE_API BOOL CenterStartMenu(BOOL enable);
SILVERAROWANACORE_API BOOL CenterTaskListIcon(BOOL enable);
SILVERAROWANACORE_API BOOL BlurTaskbar(ACCENT_POLICY);
SILVERAROWANACORE_API VOID SetDesktopIcon(DESKTOPICONS, BOOL);
SILVERAROWANACORE_API BOOL GetDesktopIconState(DESKTOPICONS);
SILVERAROWANACORE_API VOID RefreshDesktop();
SILVERAROWANACORE_API HRESULT CreateLink(LPCWSTR lpszPathObj,LPCTSTR lpszPathLink, LPCTSTR lpszArgs, LPCWSTR lpszDesc);
SILVERAROWANACORE_API BOOL GetGodModeShortCutState();
SILVERAROWANACORE_API BOOL CreateGodModeShortCut();
SILVERAROWANACORE_API BOOL RemoveGodModeShortCut();
SILVERAROWANACORE_API BOOL RemoveShortcutArrow();
SILVERAROWANACORE_API BOOL RestoreShortcutArrow();
SILVERAROWANACORE_API BOOL RegisterWindowsPhotoViewerFormat();
SILVERAROWANACORE_API BOOL UnregisterWindowsPhotoViewerFormat();
SILVERAROWANACORE_API BOOL PaintVersionInfo(BOOL enable);


SILVERAROWANACORE_API BOOL EmbedWindowToDesktop(LPCTSTR lpWindowName);
