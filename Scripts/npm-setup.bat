@ECHO OFF
CLS

IF EXIST node_modules (ECHO Removed directory - node_modules... && RMDIR /Q /S node_modules)
IF EXIST package.json (ERASE /F /Q /S package.json)
IF EXIST package-lock.json (ERASE /F /Q /S package-lock.json)
ECHO.

CALL npm init --yes && ECHO Created file - package.json
ECHO.

CALL npm pkg set scripts.install-browser-sync="npm install browser-sync" && ECHO Added script install-browser-sync
CALL npm pkg set scripts.install-cssnano="npm install cssnano"           && ECHO Added script install-cssno
CALL npm pkg set scripts.install-gulp="npm install gulp"                 && ECHO Added script install-gulp
CALL npm pkg set scripts.install-gulp-postcss="npm install gulp-postcss" && ECHO Added script install-gulp-postcss
CALL npm pkg set scripts.install-gulp-sass="npm install gulp-sass"       && ECHO Added script install-gulp-sass
CALL npm pkg set scripts.install-gulp-terser="npm install gulp-terser"   && ECHO Added script install-gulp-terser
ECHO.

ECHO Installing browser-sync... && CALL npm run install-browser-sync && ECHO.
ECHO Installing cssnano...      && CALL npm run install-cssnano      && ECHO.
ECHO Installing gulp...         && CALL npm run install-gulp         && ECHO.
ECHO Installing gulp-postcss... && CALL npm run install-gulp-postcss && ECHO.
ECHO Installing gulp-sass...    && CALL npm run install-gulp-sass    && ECHO.
ECHO Installing gulp-terser...  && CALL npm run install-gulp-terser  && ECHO.

PAUSE