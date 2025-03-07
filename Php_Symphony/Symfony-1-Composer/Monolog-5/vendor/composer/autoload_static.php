<?php

// autoload_static.php @generated by Composer

namespace Composer\Autoload;

class ComposerStaticInitf99cdc465c353fa45792c6fc3d9ca9cc
{
    public static $prefixLengthsPsr4 = array (
        'P' => 
        array (
            'Psr\\Log\\' => 8,
        ),
        'M' => 
        array (
            'Monolog\\' => 8,
        ),
    );

    public static $prefixDirsPsr4 = array (
        'Psr\\Log\\' => 
        array (
            0 => __DIR__ . '/..' . '/psr/log/src',
        ),
        'Monolog\\' => 
        array (
            0 => __DIR__ . '/..' . '/monolog/monolog/src/Monolog',
        ),
    );

    public static $classMap = array (
        'Composer\\InstalledVersions' => __DIR__ . '/..' . '/composer/InstalledVersions.php',
    );

    public static function getInitializer(ClassLoader $loader)
    {
        return \Closure::bind(function () use ($loader) {
            $loader->prefixLengthsPsr4 = ComposerStaticInitf99cdc465c353fa45792c6fc3d9ca9cc::$prefixLengthsPsr4;
            $loader->prefixDirsPsr4 = ComposerStaticInitf99cdc465c353fa45792c6fc3d9ca9cc::$prefixDirsPsr4;
            $loader->classMap = ComposerStaticInitf99cdc465c353fa45792c6fc3d9ca9cc::$classMap;

        }, null, ClassLoader::class);
    }
}
