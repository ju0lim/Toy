#include <stdio.h>
#include <stdlib.h>
#include <windows.h>

DWORD WINAPI AddAsync(LPVOID lpParam);
CRITICAL_SECTION CriticalSection;

int g_sharedData = 0;

int main()
{
    HANDLE* hThreads;
    int threadCount = 0;

    printf("스레드 개수를 입력하세요: ");
    scanf_s("%d", &threadCount);

    hThreads = (HANDLE*)malloc(threadCount * sizeof(HANDLE));
    if (hThreads == NULL) {
        fprintf(stderr, "메모리 할당 실패\n");
        return 1;
    }

    InitializeCriticalSection(&CriticalSection);

    for (int i = 0; i < threadCount; i++)
    {
        hThreads[i] = CreateThread(NULL, 0, AddAsync, NULL, 0, NULL);
        if (hThreads[i] == NULL)
        {
            fprintf(stderr, "스레드 생성 실패\n");
            free(hThreads);
            DeleteCriticalSection(&CriticalSection);
            return 1;
        }
    }

    WaitForMultipleObjects(threadCount, hThreads, TRUE, INFINITE);
    printf("Final value of sharedData: %d\n", g_sharedData);

    for (int i = 0; i < threadCount; i++)
    {
        CloseHandle(hThreads[i]);
    }

    free(hThreads);

    DeleteCriticalSection(&CriticalSection);

    return 0;
}

DWORD WINAPI AddAsync(LPVOID lpParam)
{
    for (int i = 0; i < 10000; i++)
    {
        EnterCriticalSection(&CriticalSection);
        g_sharedData++;
        LeaveCriticalSection(&CriticalSection);
    }
    return 0;
}