# Local Value Debug Repo

This repo is a MRE for the issue here: https://github.com/dotnet/wpf/issues/8786

# Steps

Run the application. The debugger will automatically break twice.

The first break will show the normal behavior (`localValue` and `actualValue` will both be `{10,10,10,10}`).

The second break will show the unexpected behavior (`localValue` will be `DependencyProperty.UnsetValue` and `actualValue` will be `{10,10,10,10}`).

# Version

.NET 7
