#include "pch.h"
#include "CppUnitTest.h"
#include "../Master-Zhao.Core/StartupTool.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace MasterZhaoCoreTests
{
	TEST_CLASS(MasterZhaoCoreTests)
	{
	public:

		TEST_METHOD(TestGetStartupItemList)
		{
			int count = 10;
			int size = sizeof(tagSTARTUPITEM) * count;
			byte* buffer = new byte[size];

			GetStartupItems(buffer, size, &count);

			delete[] buffer;
		}

		TEST_METHOD(TestDisableStartupItem)
		{
			int count = 10;
			int size = sizeof(tagSTARTUPITEM) * count;
			byte* buffer = new byte[size];

			GetStartupItems(buffer, size, &count);

			tagSTARTUPITEM* item = (tagSTARTUPITEM*)buffer;

			auto result = DisableStartupItem(item->hKey, item->szRegPath, item->samDesired, item->szName, item->szPath);

			delete[] buffer;

			Assert::IsTrue(result);
		}

		TEST_METHOD(TestEnableStartupItem)
		{
			int count = 10;
			int size = sizeof(tagSTARTUPITEM) * count;
			byte* buffer = new byte[size];

			GetStartupItems(buffer, size, &count);

			tagSTARTUPITEM* item = (tagSTARTUPITEM*)buffer;

			auto result = EnableStartupItem(item->hKey, item->szRegPath, item->samDesired, item->szName, item->szPath);

			delete[] buffer;

			Assert::IsTrue(result);
		}
	};
}