@ECHO OFF
CLS

IF EXIST node_modules (RMDIR /Q /S node_modules && ECHO Removed directory - node_modules...)
IF EXIST package.json (ERASE /F /Q /S package.json)
IF EXIST package-lock.json (ERASE /F /Q /S package-lock.json)
ECHO.

CALL npm init --yes && ECHO Created file - package.json
ECHO.

CALL npm pkg set scripts.install-autoprefixer="npm install --save-dev autoprefixer"       && ECHO Added script - install-autoprefixer
CALL npm pkg set scripts.install-browser-sync="npm install --save-dev browser-sync"       && ECHO Added script - install-browser-sync
CALL npm pkg set scripts.install-cssnano="npm install --save-dev cssnano"                 && ECHO Added script - install-cssno
CALL npm pkg set scripts.install-gulp="npm install --save-dev gulp"                       && ECHO Added script - install-gulp
CALL npm pkg set scripts.install-gulp-postcss="npm install --save-dev gulp-postcss"       && ECHO Added script - install-gulp-postcss
CALL npm pkg set scripts.install-gulp-sass="npm install --save-dev gulp-sass"             && ECHO Added script - install-gulp-sass
CALL npm pkg set scripts.install-gulp-sourcemaps="npm install --save-dev gulp-sourcemaps" && ECHO Added script - install-gulp-sourcemaps
CALL npm pkg set scripts.install-gulp-terser="npm install --save-dev gulp-terser"         && ECHO Added script - install-gulp-terser
CALL npm pkg set scripts.install-sass="npm install --save-dev sass"                       && ECHO Added script - install-sass
ECHO.

ECHO Installing autoprefixer...    && CALL npm run install-autoprefixer    && ECHO.
ECHO Installing browser-sync...    && CALL npm run install-browser-sync    && ECHO.
ECHO Installing cssnano...         && CALL npm run install-cssnano         && ECHO.
ECHO Installing gulp...            && CALL npm run install-gulp            && ECHO.
ECHO Installing gulp-postcss...    && CALL npm run install-gulp-postcss    && ECHO.
ECHO Installing gulp-sass...       && CALL npm run install-gulp-sass       && ECHO.
ECHO Installing gulp-sourcemaps... && CALL npm run install-gulp-sourcemaps && ECHO.
ECHO Installing gulp-terser...     && CALL npm run install-gulp-terser     && ECHO.
ECHO installing sass...            && CALL npm run install-sass            && ECHO.

PAUSE