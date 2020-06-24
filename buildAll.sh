function build {
    local pwd="$PWD"
    for proj in $@; do
        cd "$proj" && dotnet build; cd "$pwd"
    done
}

build "netcoreConsole" "netcoreWebapi" "vulnerable_asp_net_core"
