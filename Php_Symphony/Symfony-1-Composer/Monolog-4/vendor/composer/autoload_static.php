<?php

// autoload_static.php @generated by Composer

namespace Composer\Autoload;

class ComposerStaticInitd4bfd073ab2628e68c263d14fc46c1aa
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
            0 => __DIR__ . '/..' . '/psr/log/Psr/Log',
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
            $loader->prefixLengthsPsr4 = ComposerStaticInitd4bfd073ab2628e68c263d14fc46c1aa::$prefixLengthsPsr4;
            $loader->prefixDirsPsr4 = ComposerStaticInitd4bfd073ab2628e68c263d14fc46c1aa::$prefixDirsPsr4;
            $loader->classMap = ComposerStaticInitd4bfd073ab2628e68c263d14fc46c1aa::$classMap;

        }, null, ClassLoader::class);
    }
}
