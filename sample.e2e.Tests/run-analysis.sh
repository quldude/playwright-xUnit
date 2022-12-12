#!/bin/bash

dotnet test *.Tests.dll --logger "console;verbosity=detailed"
testExitCode=$? # Save the exit code
if (($testExitCode != 0)); then
    echo "[e2e] Tests failed."
else
    echo "[e2e] Tests passed."
fi

exit $testExitCode
