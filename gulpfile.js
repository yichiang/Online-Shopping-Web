// JavaScript source code
/// <binding ProjectOpened='build, bundle' />
var gulp = require('gulp'),
    tsc = require('gulp-typescript'),
    rimraf = require('rimraf');

var paths = {
    ts: {
        src: ["ts/*.ts", "typings/main.d.ts"],
        dest: "wwwroot/app"
    },
    npm: "node_modules/",
    libDest: "wwwroot",
    lib: "wwwroot/lib/"
}

gulp.task("build", function () {

    var tsProject = tsc.createProject("tsConfig.json");

    return gulp.src(paths.ts.src)
            .pipe(tsc(tsProject))
            .pipe(gulp.dest(paths.ts.dest));


});

gulp.task("bundle", function () {

    gulp.src(paths.npm + "systemjs/dist/**/*.*", { base: paths.npm + "systemjs/dist/" })
        .pipe(gulp.dest(paths.lib + "systemjs/"));

    gulp.src(paths.npm + "angular2/bundles/**/*.js", { base: paths.npm + "angular2/bundles/" })
        .pipe(gulp.dest(paths.lib + "angular2/"));

    gulp.src(paths.npm + "es6-shim/es6-sh*", { base: paths.npm + "es6-shim/" })
        .pipe(gulp.dest(paths.lib + "es6-shim/"));

    gulp.src(paths.npm + "es6-promise/dist/**/*.*", { base: paths.npm + "es6-promise/dist/" })
        .pipe(gulp.dest(paths.lib + "es6-promise/"));

    gulp.src(paths.npm + "rxjs/bundles/*.*", { base: paths.npm + "rxjs/bundles/" })
        .pipe(gulp.dest(paths.lib + "rxjs/"));

    gulp.src(paths.npm + "bootstrap/dist/js/*.*", { base: paths.npm + "bootstrap/dist/js" })
        .pipe(gulp.dest(paths.lib + "bootstrap/"));

})

gulp.task("bundle:css", function () {

    gulp.src(paths.npm + "bootstrap/dist/css/bootstrap.min.css")
        .pipe(gulp.dest(paths.libDest + "/css"));

    gulp.src(paths.npm + "bootstrap/dist/fonts/*.*")
        .pipe(gulp.dest(paths.libDest + "/fonts"));

})

gulp.task("watch", function () {

    return gulp.watch(paths.ts.src, ["build"]);

})


gulp.task('default', ['build', 'bundle', 'bundle:css', 'watch'], function () {
    // place code for your default task here
});