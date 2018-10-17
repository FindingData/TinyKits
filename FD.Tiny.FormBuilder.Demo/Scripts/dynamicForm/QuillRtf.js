var quillRtf = {
    props: ['eidtEnabled', 'contents'],
    data() {
        return {
            quillId: '',
            quill: null,
            toolbarOptions: [
                ['bold', 'italic', 'underline', 'strike'],        // toggled buttons
                ['blockquote', 'code-block'],

                [{ 'header': 1 }, { 'header': 2 }],               // custom button values
                [{ 'list': 'ordered' }, { 'list': 'bullet' }],
                [{ 'script': 'sub' }, { 'script': 'super' }],      // superscript/subscript
                [{ 'indent': '-1' }, { 'indent': '+1' }],          // outdent/indent
                [{ 'direction': 'rtl' }],                         // text direction

                [{ 'size': ['small', false, 'large', 'huge'] }],  // custom dropdown
                [{ 'header': [1, 2, 3, 4, 5, 6, false] }],

                [{ 'color': [] }, { 'background': [] }],          // dropdown with defaults from theme
                [{ 'font': [] }],
                [{ 'align': [] }],

                ['clean']                                         // remove formatting button
            ]
        }
    },
    created() {
        this.quillId = 'quill' + new Date().getTime()
    },
    methods: {
        //初始化
        init() {
            if (this.eidtEnabled) {
                this.quill = new Quill('#' + this.quillId, {
                    modules: {
                        toolbar: this.toolbarOptions
                    },
                    placeholder: 'Compose an epic...',
                    theme: 'snow'  // or 'bubble'
                })
                this.quill.on('text-change', () => {
                    this.$emit('text-change', this.quill.getContents().ops)
                })
            } else {
                this.quill = new Quill('#' + this.quillId, {
                    modules: {
                        toolbar: []
                    },
                    theme: 'snow'  // or 'bubble'
                })
            }
            this.quill.setContents(this.contents)
            this.quill.enable(this.eidtEnabled);    
        }
    },
    mounted() {
        this.init()
    },
    template: `
        <div :class="{'ql-rtf-enable':!eidtEnabled}">
            <div :id="quillId">
            </div>
        </div>
    `
}