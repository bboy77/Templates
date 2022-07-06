const { src, dest, watch, series } = require("gulp");

const sass = require("gulp-sass")(require("sass"));

function scssTask() {
    return src("wwwroot/scss/site.scss", { sourcemaps: true })
        .pipe(sass())
        .pipe(dest("wwwroot/css", { sourcemaps: "." }));
}

function watchTask() {
    watch("wwwroot/scss/**/*.scss", series(scssTask));
}

exports.default = series(scssTask, watchTask);