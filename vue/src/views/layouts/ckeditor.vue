﻿<template>
    <div class="ckeditor">
        <textarea :name="name"
                  :id="id"
                  :value="value"
                  :types="types"
                  :config="config">
        </textarea>
    </div>
</template>

<script>
    export default {
        name: 'vue-ckeditor',
        props: {
            name: {
                type: String,
                default: () => `editor`
            },
            value: {
                type: String
            },
            id: {
                type: String,
                default: () => `editor`
            },
            types: {
                type: String,
                default: () => `classic`
            },
            config: {
                type: Object,
                default: () => { }
            }
        },
        data() {
            return { destroyed: false }
        },
        computed: {
            instance() {
                return CKEDITOR.instances[this.id]
            }
        },
        watch: {
            value(val) {
                if (this.instance) {
                    this.update(val)
                }
            }
        },
        mounted() {
            this.create()
        },
        beforeDestroy() {
            this.destroy()
        },
        methods: {
            create() {
                if (typeof CKEDITOR === 'undefined') {
                    console.log('CKEDITOR is missing (http://ckeditor.com/)')
                } else {
                    if (this.types === 'inline') {
                        CKEDITOR.inline(this.id, this.config)
                    } else {
                        CKEDITOR.replace(this.id, this.config)
                    }
                    this.instance.setData(this.value)
                    this.instance.on('change', this.onChange)
                    this.instance.on('blur', this.onBlur)
                    this.instance.on('focus', this.onFocus)
                }
            },
            update(val) {
                let html = this.instance.getData()
                if (html !== val) {
                    this.instance.setData(val)
                }
            },
            destroy() {
                if (!this.destroyed) {
                    this.instance.focusManager.blur(true)
                    this.instance.removeAllListeners()
                    this.instance.destroy()
                    this.destroyed = true
                }
            },
            onChange() {
                let html = this.instance.getData()
                if (html !== this.value) {
                    this.$emit('input', html)
                }
            },
            onBlur() {
                this.$emit('blur', this.instance)
            },
            onFocus() {
                this.$emit('focus', this.instance)
            }
        }
    }
</script>