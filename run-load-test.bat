@echo off
echo Starting Disaster Relief App Load Test...
echo.

REM Check if JMeter is installed
where jmeter >nul 2>&1
if %errorlevel% neq 0 (
    echo JMeter is not installed or not in PATH.
    echo Please install JMeter from: https://jmeter.apache.org/download_jmeter.cgi
    pause
    exit /b 1
)

REM Create results directory if it doesn't exist
if not exist "results" mkdir results

REM Run the load test
echo Running load test...
jmeter -n -t disaster-relief-load-test.jmx -l results/load-test-results.jtl -e -o results/report

echo.
echo Load test completed!
echo Results saved to: LoadTests/results/
echo Open results/report/index.html to view the report
pause